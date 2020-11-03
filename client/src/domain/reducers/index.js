import { combineReducers } from 'redux';
import { connectRouter } from 'connected-react-router'
import auth from './authReducer';
import app from './appReducer';
import garden from './gardenReducer';

export default (history) => combineReducers({
    app,
    auth,
    garden,
    router: connectRouter(history)
});