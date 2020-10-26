import React from 'react';
import { Redirect, Route } from 'react-router'
import Login from '../screens/Login/Login';

export const Routes = ({ user }) => {
    return (
        !user ?
        <>
            <Route exact path="/" component={Login} />
            <Route exact path="/Login" component={Login} />
            <Route exact path="/Register" component={() => <div>Register</div>} />
            <Route exact path="/ForgotPassword" component={() => <div>Forgot Password</div>} />
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