import { TOGGLE_SIDEBAR } from "../types/appTypes";

export const toggleSidebar = () => async dispatch => {
    dispatch({
        type: TOGGLE_SIDEBAR,
    })
} 