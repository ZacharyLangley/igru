import { combineReducers } from 'redux';
import { connectRouter } from 'connected-react-router'
import auth from './authReducer';
import app from './appReducer';
import garden from './gardenReducer';
import plant from './plantReducer';
import nutrientRecipe from './nutrientRecipeReducer';

export default (history) => combineReducers({
    app,
    auth,
    garden,
    nutrientRecipe,
    plant,
    router: connectRouter(history)
});