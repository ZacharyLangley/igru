import { SIGNIN_USER, LOAD_USER, SIGNOUT_USER, REGISTER_USER, LOGIN_FAILED } from '../types/authTypes';

const initialState = {
    user: null,
    isAuthenticated: false,
    hasError: false
}

export default function(state = initialState, action) {
    switch(action.type) {
        case REGISTER_USER:
            return {
                ...state
            }
        case SIGNIN_USER:
            return {
                ...state,
                hasError: false,
                user: action.payload,
                isAuthenticated: true
            }
        case LOAD_USER:
            return {
                ...state,
                hasError: false,
                user: action.payload.accessToken.payload.username,
                isAuthenticated: true
            }
        case SIGNOUT_USER:
            return {
                ...state,
                user: null,
                hasError: false,
                isAuthenticated: false
            }
        case LOGIN_FAILED:
            return {
                ...state,
                hasError: true
            }
        default:
            return state;
    }
}