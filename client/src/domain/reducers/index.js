import { combineReducers } from 'redux';
import { connectRouter } from 'connected-react-router'
import auth from './authReducer';
import app from './appReducer';

export default (history) => combineReducers({
    app,
    auth,
    router: connectRouter(history)
});