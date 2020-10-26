import React from 'react';
import { Route, Redirect} from 'react-router-dom';

const PrivateRoute = ({ user, component: Component, ...rest }) => (
    <Route {...rest} render={(props) => (
      user
        ? <Component {...props} />
        : <Redirect to='/Login' />
    )} />
)

export default PrivateRoute;