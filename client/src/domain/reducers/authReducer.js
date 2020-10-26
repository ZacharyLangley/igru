import { SIGNIN_USER, LOAD_USER, SIGNOUT_USER, REGISTER_USER, LOGIN_FAILED } from '../types/authTypes';

const initialState = {
    user: undefined,
    hasError: false
}

export default function(state = initialState, action) {
    switch(action.type) {
        case REGISTER_USER:
            return {
                ...state,
                user: action.payload
            }
        case SIGNIN_USER:
            return {
                ...state,
                hasError: false,
                user: action.payload,
            }
        case LOAD_USER:
            return {
                ...state,
                hasError: false,
                user: action.payload,
            }
        case SIGNOUT_USER:
            return {
                ...state,
                user: null,
                hasError: false,
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