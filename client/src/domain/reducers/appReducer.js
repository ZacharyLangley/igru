import { TOGGLE_SIDEBAR } from '../types/appTypes';

const initialState = {
    isSidebarOpen: false
}

export default function(state = initialState, action) {
    switch(action.type) {
        case TOGGLE_SIDEBAR:
            return {
                ...state,
                isSidebarOpen: !state.isSidebarOpen
            }
        default:
            return state;
    }
}