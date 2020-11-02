import React from 'react';
import AllInboxIcon from '@material-ui/icons/AllInbox';
import LocalFloristIcon from '@material-ui/icons/LocalFlorist';
import WcIcon from '@material-ui/icons/Wc';
import MenuBookIcon from '@material-ui/icons/MenuBook';
import SettingsIcon from '@material-ui/icons/Settings';

const sidebarOptions = [
    {
        label: 'Gardens',
        icon: <AllInboxIcon />,
        path: '/Gardens'
    },
    {
        label: 'Plants',
        icon: <LocalFloristIcon />,
        path: '/Plants'
    }, 
    {
        label: 'Strains',
        icon: <WcIcon />,
        path: '/Strains'
    },
    {
        label: 'Nutrient Recipes',
        icon: <MenuBookIcon />,
        path: '/Nutrient-Recipes'
    },
    {
        label: 'Settings',
        icon: <SettingsIcon />,
        path: '/Settings'
    }
]

export default sidebarOptions