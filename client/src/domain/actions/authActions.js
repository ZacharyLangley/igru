import { SIGNIN_USER, LOAD_USER, SIGNOUT_USER } from '../types/authTypes';
import API, { handleError } from '../util/api';

export const signinUser = (email, password, push) => async dispatch => {
    try {
        const user = await API.post('/user/login', {
            email,
            password,
        });
        dispatch({
            type: SIGNIN_USER,
            payload: user.data
        })
        // push('/');
    } catch (e) {
        return handleError(e, dispatch)
    }
}

export const loadUser = () => async dispatch => {
    try {
        dispatch({
            type: LOAD_USER,
            payload: {}
        })
    } catch (e) {
        return alert(e.message);
    }
}

export const logoutUser = () => async dispatch => {
    dispatch({
        type: SIGNOUT_USER
    })
}