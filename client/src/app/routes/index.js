import React from 'react';

import PrivateRoute from './PrivateRoute';
import SessionRoute from './SessionRoute';

import Login from '../screens/Login/Login';
import Register from '../screens/Register/Register';

import Home from '../screens/Home/Home';
import Gardens from '../screens/Gardens/Gardens';
import GardenItem from '../screens/Gardens/GardenItem/GardenItem';
import NutrientRecipes from '../screens/NutrientRecipes/NutrientRecipes';
import NutrientRecipeItem from '../screens/NutrientRecipes/NutrientRecipeItem/NutrientRecipeItem';
import Plants from '../screens/Plants/Plants';
import PlantItem from '../screens/Plants/PlantItem/PlantItem';
import Settings from '../screens/Settings/Settings';
import Strains from '../screens/Strains/Strains';
import StrainItem from '../screens/Strains/StrainItem/StrainItem';


export const AuthRoutes = ({ user }) => {
    return (
        <>
            <SessionRoute user={user} exact path="/" component={Login} />
            <SessionRoute user={user} exact path="/Login" component={Login} />
            <SessionRoute user={user} exact path="/Register" component={Register} />
        </>
    ) 
}

export const AppRoutes = ({ user }) => {
    return (
        <>
            <PrivateRoute user={user} exact path={'/'} component={Home} />
            <PrivateRoute user={user} exact path={'/Gardens'} component={Gardens} />
            <PrivateRoute user={user} exact path={'/Gardens/:id'} component={GardenItem} />

            <PrivateRoute user={user} exact path={'/Plants'} component={Plants} />
            <PrivateRoute user={user} exact path={'/Plants/:id'} component={PlantItem} />

            <PrivateRoute user={user} exact path={'/Strains'} component={Strains} />
            <PrivateRoute user={user} exact path={'/Strains/:id'} component={StrainItem} />

            <PrivateRoute user={user} exact path={'/Nutrient-Recipes'} component={NutrientRecipes} />
            <PrivateRoute user={user} exact path={'/Nutrient-Recipes/:id'} component={NutrientRecipeItem} />

            <PrivateRoute user={user} exact path={'/Settings'} component={Settings} />
        </>
    ) 
}