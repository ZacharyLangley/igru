import React from 'react';
import { connect } from 'react-redux'
import { push } from 'connected-react-router'
import { object, func } from 'prop-types';
import MenuIcon from '@material-ui/icons/Menu';
import MenuOpenIcon from '@material-ui/icons/MenuOpen';
import { MenuItem } from '@material-ui/core';
import ArrowDropDownIcon from '@material-ui/icons/ArrowDropDown';
import AccountCircleIcon from '@material-ui/icons/AccountCircle';

import { logoutUser } from 'domain/actions/authActions';
import { toggleSidebar } from 'domain/actions/appActions';
import { IconButton, Dropdown } from 'common/components';

import './Header.scss';

const Header = ({
    logoutUser,
    push,
    isSidebarOpen,
    toggleSidebar,
    user,
}) => {

    const { displayName, username } = user;
    const formattedUsername = displayName ? displayName.charAt(0).toUpperCase() + username.slice(1) : username.charAt(0).toUpperCase() + username.slice(1);

    const getMenuButton = () => {
        const menuButtonStyles = {color: '#4eae53'};
        return (
            <div className={'igru-menu-button'}>
                <IconButton aria-label="menu-toggle" onClick={toggleSidebar}>
                    {
                        isSidebarOpen ?
                        <MenuOpenIcon  style={menuButtonStyles}/> :
                        <MenuIcon style={menuButtonStyles}/>
                    }
                </IconButton>
            </div>
        )
    }

    const getBranding = () => {
        return (
            <div className={'brand-container'}>

            </div>
        )
    }

    const getAvatar = () => {
        const menuItems = [
            {
                title: `Hello, ${formattedUsername}`,
                onSelect: () => push('/Profile')
            },
            {
                title: `Logout`,
                onSelect: () => logoutUser() 
            }
        ];
        return (
            <Dropdown menuItems={menuItems}>
                <div className={'util-button'}>
                    <div className={'down-icon'}>
                        <ArrowDropDownIcon />
                    </div>
                    <div className={'avatar-icon'}>
                        <AccountCircleIcon/>
                    </div>
                </div>
            </Dropdown>
        )
    }
    
    const toProfile = () => {
        push('/profile')
    }

    const onLogout = async () => {
        logoutUser();
    }

    return (
        <div className={'header-container'}>
            {getMenuButton()}
            {getBranding()}
            {getAvatar()}
        </div>
    )
}

const mapStateToProps = (state) => ({
    user: state.auth.user,
    isSidebarOpen: state.app.isSidebarOpen
})

const mapDispatchToProps = {
    push,
    toggleSidebar,
    logoutUser
}

Header.propTypes = {
    user: object,
    toggleSidebar: func,
    push: func,
    logoutUser: func
}

export default connect(mapStateToProps, mapDispatchToProps)(Header);