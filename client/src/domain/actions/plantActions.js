import { 
    API,
    getAuthHeaders,
    handleError,
} from '../util/api';


export const getPlantList = async (limit=30, offset=0, startDate='') => {
    try {
        const headers = getAuthHeaders()
        const plantList = await API.get(`/plants?limit=${30}&offset=${offset}&startDate=${startDate}`, {headers})
        return plantList.data;
    } catch(e) {
        alert(e)
    }
}

export const getPlantItem = (plantId) => async dispatch => {
    try {
        const headers = getAuthHeaders()
        const plantItem = await API.get(`/plants/${plantId}`, {headers})
        return plantItem;
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const createPlantItem = (plant) => async dispatch => {
    try {
        const headers = getAuthHeaders()
        const plantItem = await API.post(`/plants`, plant, {headers})
        // Create an alert for successful creation of a plant. The user must be notified
        // and navigated back to Plant Dashboard or close whatever modal holds the form
        return plantItem
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const updatePlantItem = (plant) => async dispatch => {
    try {
        const headers = getAuthHeaders()
        const plantItem = await API.put(`/plants`, plant, {headers})
        // Create an alert for successful edit of a plant. The user must be notified
        // and navigated back to Plant Dashboard or close whatever modal holds the form
        return plantItem
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const deletePlantItem = (plantId) => async dispatch => {
    try {
        const headers = getAuthHeaders()
        const plantItem = await API.delete(`/plants/${plantId}`, {headers})
        // Create an alert for successful deletion of a plant. The user must be notified
        // and navigated back to Plant Dashboard or close whatever modal holds the form
        return plantItem
    } catch(e) {
        return handleError(e, dispatch)
    }
}