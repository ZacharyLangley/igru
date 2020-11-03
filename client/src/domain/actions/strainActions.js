import Cookies from 'js-cookie';
import { 
    API,
    getAuthHeaders,
    handleError,
} from '../util/api';


export const getStrainList = (limit=30, offset=0, startDate='') => {
    try {
        const headers = getAuthHeaders()
        const strainList = await API.get(`/api/strains?limit=${30}&offset=${offset}&startDate=${startDate}`, {headers})
        return strainList;
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const getStrainItem = (strainId) => {
    try {
        const headers = getAuthHeaders()
        const strainItem = await API.get(`/api/strains/${strainId}`, {headers})
        return strainItem;
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const createStrainItem = (strain) => {
    try {
        const headers = getAuthHeaders()
        const strainItem = await API.post(`/api/strains`, strain, {headers})
        // Create an alert for successful creation of a strain. The user must be notified
        // and navigated back to Strain Dashboard or close whatever modal holds the form
        return strainItem
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const updateStrainItem = (strain) => {
    try {
        const headers = getAuthHeaders()
        const strainItem = await API.put(`/api/strains`, strain, {headers})
        // Create an alert for successful edit of a strain. The user must be notified
        // and navigated back to Strain Dashboard or close whatever modal holds the form
        return strainItem
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const deleteStrainItem = (strainId) => {
    try {
        const headers = getAuthHeaders()
        const strainItem = await API.delete(`/api/strains/${strainId}`, {headers})
        // Create an alert for successful deletion of a strain. The user must be notified
        // and navigated back to Strain Dashboard or close whatever modal holds the form
        return strainItem
    } catch(e) {
        return handleError(e, dispatch)
    }
}