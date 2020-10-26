import { push } from 'connected-react-router';
import Cookies from 'js-cookie'

import { SIGNIN_USER, LOAD_USER, SIGNOUT_USER, REGISTER_USER } from '../types/authTypes';
import API, { handleError } from '../util/api';

export const JWT_PROPERTY_NAME = 'igru-jwt-token'
export const COOKIE_CONFIG = { expires: 7 }

export const signinUser = (email, password, push) => async dispatch => {
    try {
        const user = await API.post('/user/login', {
            email,
            password,
        });

        Cookies.set(JWT_PROPERTY_NAME, user.data.token, COOKIE_CONFIG);
        dispatch({
            type: SIGNIN_USER,
            payload: user.data
        })
        push('/Gardens');
    } catch (e) {
        return handleError(e, dispatch)
    }
}

export const registerUser = (email, username, displayName, password) => async dispatch => {
    try {
        const user = await API.post('/user/register', {
            email,
            username,
            displayName,
            password
        });
        Cookies.set(JWT_PROPERTY_NAME, user.data.token, COOKIE_CONFIG);

        dispatch({
            type: REGISTER_USER,
            payload: user.data
        })
        push('/Gardens')
    } catch (e) {
        return handleError(e, dispatch)
    }
}

export const loadUser = (push) => async dispatch => {
    try {
        const token = Cookies.get(JWT_PROPERTY_NAME);
        const headers = {
            'Authorization': `Bearer ${token}`
        }
        const user = await API.get('/user', {headers});
        dispatch({
            type: LOAD_USER,
            payload: user.data
        })
    } catch (e) {
        dispatch({
            type: LOAD_USER,
            payload: undefined
        })
    }
}

export const logoutUser = () => async dispatch => {
    dispatch({
        type: SIGNOUT_USER
    })
}