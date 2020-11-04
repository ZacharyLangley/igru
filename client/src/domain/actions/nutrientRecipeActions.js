import Cookies from 'js-cookie';
import { 
    API,
    getAuthHeaders,
    handleError,
} from '../util/api';


export const getNutrientRecipeList = (limit=30, offset=0, startDate='') => async dispatch => {
    try {
        const headers = getAuthHeaders()
        const nutrientRecipeList = await API.get(`/nutrientRecipes?limit=${30}&offset=${offset}&startDate=${startDate}`, {headers})
        return nutrientRecipeList;
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const getNutrientRecipeItem = (nutrientRecipeId) => async dispatch => {
    try {
        const headers = getAuthHeaders()
        const nutrientRecipeItem = await API.get(`/nutrientRecipes/${nutrientRecipeId}`, {headers})
        return nutrientRecipeItem;
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const createNutrientRecipeItem = (nutrientRecipe) => async dispatch => {
    try {
        const headers = getAuthHeaders()
        const nutrientRecipeItem = await API.post(`/nutrientRecipes`, nutrientRecipe, {headers})
        // Create an alert for successful creation of a nutrientRecipe. The user must be notified
        // and navigated back to Nutrient Recipe Dashboard or close whatever modal holds the form
        return nutrientRecipeItem
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const updateNutrientRecipeItem = (nutrientRecipe) => async dispatch => {
    try {
        const headers = getAuthHeaders()
        const nutrientRecipeItem = await API.put(`/nutrientRecipes`, nutrientRecipe, {headers})
        // Create an alert for successful edit of a nutrientRecipe. The user must be notified
        // and navigated back to Nutrient Recipe Dashboard or close whatever modal holds the form
        return nutrientRecipeItem
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const deleteNutrientRecipeItem = (nutrientRecipeId) => async dispatch => {
    try {
        const headers = getAuthHeaders()
        const nutrientRecipeItem = await API.delete(`/nutrientRecipes/${nutrientRecipeId}`, {headers})
        // Create an alert for successful deletion of a nutrientRecipe. The user must be notified
        // and navigated back to Nutrient Recipe Dashboard or close whatever modal holds the form
        return nutrientRecipeItem
    } catch(e) {
        return handleError(e, dispatch)
    }
}