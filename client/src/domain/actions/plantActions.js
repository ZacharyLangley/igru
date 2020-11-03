import Cookies from 'js-cookie';
import { 
    API,
    getAuthHeaders,
    handleError,
} from '../util/api';


export const getPlantList = (limit=30, offset=0, startDate='') => {
    try {
        const headers = getAuthHeaders()
        const plantList = await API.get(`/api/plants?limit=${30}&offset=${offset}&startDate=${startDate}`, {headers})
        return plantList;
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const getPlantItem = (plantId) => {
    try {
        const headers = getAuthHeaders()
        const plantItem = await API.get(`/api/plants/${plantId}`, {headers})
        return plantItem;
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const createPlantItem = (plant) => {
    try {
        const headers = getAuthHeaders()
        const plantItem = await API.post(`/api/plants`, plant, {headers})
        // Create an alert for successful creation of a plant. The user must be notified
        // and navigated back to Plant Dashboard or close whatever modal holds the form
        return plantItem
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const updatePlantItem = (plant) => {
    try {
        const headers = getAuthHeaders()
        const plantItem = await API.put(`/api/plants`, plant, {headers})
        // Create an alert for successful edit of a plant. The user must be notified
        // and navigated back to Plant Dashboard or close whatever modal holds the form
        return plantItem
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const deletePlantItem = (plantId) => {
    try {
        const headers = getAuthHeaders()
        const plantItem = await API.delete(`/api/plants/${plantId}`, {headers})
        // Create an alert for successful deletion of a plant. The user must be notified
        // and navigated back to Plant Dashboard or close whatever modal holds the form
        return plantItem
    } catch(e) {
        return handleError(e, dispatch)
    }
}