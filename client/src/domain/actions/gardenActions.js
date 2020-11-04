import Cookies from 'js-cookie';
import { 
    API,
    getAuthHeaders,
    handleError,
} from '../util/api';


export const getGardenList = (limit=30, offset=0, startDate='') => async dispatch => {
    try {
        const headers = getAuthHeaders()
        const gardenList = await API.get(`/api/gardens?limit=${30}&offset=${offset}&startDate=${startDate}`, {headers})
        return gardenList;
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const getGardenItem = (gardenId) => async dispatch => {
    try {
        const headers = getAuthHeaders()
        const gardenItem = await API.get(`/api/gardens/${gardenId}`, {headers})
        return gardenItem;
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const createGardenItem = (garden) => async dispatch => {
    try {
        const headers = getAuthHeaders()
        const gardenItem = await API.post(`/api/gardens`, garden, {headers})
        // Create an alert for successful creation of a garden. The user must be notified
        // and navigated back to Garden Dashboard or close whatever modal holds the form
        return gardenItem
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const updateGardenItem = (garden) => async dispatch => {
    try {
        const headers = getAuthHeaders()
        const gardenItem = await API.put(`/api/gardens`, garden, {headers})
        // Create an alert for successful edit of a garden. The user must be notified
        // and navigated back to Garden Dashboard or close whatever modal holds the form
        return gardenItem
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const deleteGardenItem = (gardenId) => async dispatch => {
    try {
        const headers = getAuthHeaders()
        const gardenItem = await API.delete(`/api/gardens/${gardenId}`, {headers})
        // Create an alert for successful deletion of a garden. The user must be notified
        // and navigated back to Garden Dashboard or close whatever modal holds the form
        return gardenItem
    } catch(e) {
        return handleError(e, dispatch)
    }
}