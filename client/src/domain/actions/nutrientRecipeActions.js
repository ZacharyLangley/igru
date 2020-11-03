import Cookies from 'js-cookie';
import { 
    API,
    getAuthHeaders,
    handleError,
} from '../util/api';


export const getNutrientRecipeList = (limit=30, offset=0, startDate='') => {
    try {
        const headers = getAuthHeaders()
        const nutrientRecipeList = await API.get(`/api/nutrientRecipes?limit=${30}&offset=${offset}&startDate=${startDate}`, {headers})
        return nutrientRecipeList;
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const getNutrientRecipeItem = (nutrientRecipeId) => {
    try {
        const headers = getAuthHeaders()
        const nutrientRecipeItem = await API.get(`/api/nutrientRecipes/${nutrientRecipeId}`, {headers})
        return nutrientRecipeItem;
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const createNutrientRecipeItem = (nutrientRecipe) => {
    try {
        const headers = getAuthHeaders()
        const nutrientRecipeItem = await API.post(`/api/nutrientRecipes`, nutrientRecipe, {headers})
        // Create an alert for successful creation of a nutrientRecipe. The user must be notified
        // and navigated back to Nutrient Recipe Dashboard or close whatever modal holds the form
        return nutrientRecipeItem
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const updateNutrientRecipeItem = (nutrientRecipe) => {
    try {
        const headers = getAuthHeaders()
        const nutrientRecipeItem = await API.put(`/api/nutrientRecipes`, nutrientRecipe, {headers})
        // Create an alert for successful edit of a nutrientRecipe. The user must be notified
        // and navigated back to Nutrient Recipe Dashboard or close whatever modal holds the form
        return nutrientRecipeItem
    } catch(e) {
        return handleError(e, dispatch)
    }
}

export const deleteNutrientRecipeItem = (nutrientRecipeId) => {
    try {
        const headers = getAuthHeaders()
        const nutrientRecipeItem = await API.delete(`/api/nutrientRecipes/${nutrientRecipeId}`, {headers})
        // Create an alert for successful deletion of a nutrientRecipe. The user must be notified
        // and navigated back to Nutrient Recipe Dashboard or close whatever modal holds the form
        return nutrientRecipeItem
    } catch(e) {
        return handleError(e, dispatch)
    }
}