import { combineReducers } from 'redux';
import { connectRouter } from 'connected-react-router'
import auth from './authReducer';
import app from './appReducer';
import garden from './gardenReducer';
import nutrientRecipe from './nutrientRecipeReducer';
import plant from './plantReducer';
import strain from './strainReducer';

export default (history) => combineReducers({
    app,
    auth,
    garden,
    nutrientRecipe,
    plant,
    strain,
    router: connectRouter(history)
});