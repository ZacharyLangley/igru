import axios from "axios";

export const handleError = (error, dispatch) => {
    if (error.response) {
        // The request was made and the server responded with a status code
        // that falls out of the range of 2xx
        // console.log(error.response)
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

export default axios.create({
    baseURL: "http://localhost:5000/api/",
    responseType: "json",
});
