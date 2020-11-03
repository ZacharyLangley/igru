import { SIGNIN_USER, LOAD_USER, SIGNOUT_USER, REGISTER_USER, LOGIN_FAILED } from '../types/authTypes';

const initialState = {
    hasError: false
}

export default function(state = initialState, action) {
    switch(action.type) {
        default:
            return state;
    }
}