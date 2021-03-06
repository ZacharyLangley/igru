import { push } from 'connected-react-router';
import Cookies from 'js-cookie'

import { SIGNIN_USER, LOAD_USER, SIGNOUT_USER, REGISTER_USER } from '../types/authTypes';
import { 
    API,
    COOKIE_CONFIG,
    getAuthHeaders,
    handleError,
    JWT_PROPERTY_NAME,
} from '../util/api';

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
        const headers = getAuthHeaders()
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
    Cookies.remove(JWT_PROPERTY_NAME)
    dispatch({
        type: SIGNOUT_USER
    })
}