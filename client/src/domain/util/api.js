import axios from "axios";
import Cookies from 'js-cookie'

export const JWT_PROPERTY_NAME = 'igru-jwt-token'
export const COOKIE_CONFIG = { expires: 7 }

export const getAuthHeaders = () => {
    const token = Cookies.get(JWT_PROPERTY_NAME);
    return {
        'Authorization': `Bearer ${token}`
    }
}

export const handleError = (error, dispatch) => {
    if (error.response) {
        // The request was made and the server responded with a status code
        // that falls out of the range of 2xx
        return handleHttpStatus(error.response.status)
    } else if (error.request) {
        // The request was made but no response was received
        console.log(error.request);
    } else {
        // Something happened in setting up the request that triggered an Error
        console.log('Error', error.message);
    }
    return alert(error.message);
}

export const handleHttpStatus = (status) => {
    switch(status) {
        case 401: 
            alert('Error: Invalid Credentials')
            break;
        case 500:
            alert('Error: Register Failed')
            break;
        default:
            break;
    }
}

export const API = axios.create({
    baseURL: "http://localhost:5000/api/",
    responseType: "json",
});