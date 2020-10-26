import React from 'react';
import { Route } from 'react-router-dom'

import PrivateRoute from './PrivateRoute';
import Login from '../screens/Login/Login';
import Register from '../screens/Register/Register';

// Routes has some user authentication checking, but will definately need a more secure solution
const Routes = ({ user }) => {
    return (
        <>
            <Route exact path="/" component={Login} />
            <Route exact path="/Login" component={Login} />
            <Route exact path="/Register" component={Register} />

            <PrivateRoute user={user} exact path={'/Gardens'} component={() => <div>Gardens</div>} />
            <PrivateRoute user={user} exact path={'/Gardens/:id'} component={() => <div>Garden Item</div>} />

            <PrivateRoute user={user} exact path={'/Plants'} component={() => <div>Plants</div>} />
            <PrivateRoute user={user} exact path={'/Plants/:id'} component={() => <div>Plant Item</div>} />

            <PrivateRoute user={user} exact path={'/Strains'} component={() => <div>Strains</div>} />
            <PrivateRoute user={user} exact path={'/Strains/:id'} component={() => <div>Strain Item</div>} />

            <PrivateRoute user={user} exact path={'/NutrientRecipes'} component={() => <div>NutrientRecipes</div>} />
            <PrivateRoute user={user} exact path={'/NutrientRecipes/:id'} component={() => <div>Nutrient Recipe Item</div>} />

            <PrivateRoute user={user} exact path={'/Settings'} component={() => <div>Settings</div>} />
        </>
    ) 
}

export default Routes;