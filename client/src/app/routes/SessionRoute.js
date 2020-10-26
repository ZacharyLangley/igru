import React from 'react';
import { Route, Redirect } from 'react-router-dom';

const SessionRoute = ({ user, component: Component, ...rest }) => (
    <Route {...rest} render={(props) => (
      !user
        ? <Component {...props} />
        : <Redirect to='/Gardens' />
    )} />
)

export default SessionRoute;