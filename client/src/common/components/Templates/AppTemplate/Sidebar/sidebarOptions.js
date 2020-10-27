import AllInboxIcon from '@material-ui/icons/AllInbox';
import EcoIcon from '@material-ui/icons/Eco';
import LocalFloristIcon from '@material-ui/icons/LocalFlorist';
import MenuBookIcon from '@material-ui/icons/MenuBook';
import SettingsIcon from '@material-ui/icons/Settings';

const sidebarOptions = [
    {
        label: 'Gardens',
        icon: <AllInboxIcon />,
        path: '/gardens'
    },
    {
        label: 'Plants',
        icon: <LocalFloristIcon />,
        path: '/plants'
    }, 
    {
        label: 'Strains',
        icon: <EcoIcon />,
        path: '/strains'
    },
    {
        label: 'Nutrient Recipes',
        icon: <MenuBookIcon />,
        path: '/nutrient-recipes'
    },
    {
        label: 'Settings',
        icon: <SettingsIcon />,
        path: '/settings'
    }
]

export default sidebarOptions