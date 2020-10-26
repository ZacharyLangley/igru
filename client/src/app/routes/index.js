import React from 'react';
import { Route } from 'react-router-dom'

import Login from '../screens/Login/Login';
import Register from '../screens/Register/Register';

// Routes has some user authentication checking, but will definately need a more secure solution
const Routes = ({ user }) => {
    return (
        !user ?
        <>
            <Route exact path="/" component={Login} />
            <Route exact path="/Login" component={Login} />
            <Route exact path="/Register" component={Register} />
        </> : <>
            <Route exact path={'/Gardens'} component={() => <div>Gardens</div>} />
            <Route exact path={'/Gardens/:id'} component={() => <div>Garden Item</div>} />

            <Route exact path={'/Plants'} component={() => <div>Plants</div>} />
            <Route exact path={'/Plants/:id'} component={() => <div>Plant Item</div>} />

            <Route exact path={'/Strains'} component={() => <div>Strains</div>} />
            <Route exact path={'/Strains/:id'} component={() => <div>Strain Item</div>} />

            <Route exact path={'/NutrientRecipes'} component={() => <div>NutrientRecipes</div>} />
            <Route exact path={'/NutrientRecipes/:id'} component={() => <div>Nutrient Recipe Item</div>} />

            <Route exact path={'/Settings'} component={() => <div>Settings</div>} />
        </>
    ) 
}

export default Routes;