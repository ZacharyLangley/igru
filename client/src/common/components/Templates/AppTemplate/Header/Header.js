import React from 'react';
import { connect } from 'react-redux'
import { push } from 'connected-react-router'
import { object, func } from 'prop-types';

import { logoutUser } from 'domain/actions/authActions';
import { toggleSidebar } from 'domain/actions/appActions';
import { IconButton } from 'common/components';
import MenuIcon from '@material-ui/icons/Menu';
import MenuOpenIcon from '@material-ui/icons/MenuOpen';

import './Header.scss';

const Header = ({
    logoutUser,
    push,
    isSidebarOpen,
    toggleSidebar,
    user,
}) => {
    const getMenuButton = () => {
        const menuButtonStyles = {color: '#4eae53'};
        return (
            <div className={'igru-menu-button'}>
                <IconButton aria-label="menu-toggle" onClick={toggleSidebar}>
                    {
                        isSidebarOpen ?
                        <MenuOpenIcon fontSize="large" style={menuButtonStyles}/> :
                        <MenuIcon fontSize="large" style={menuButtonStyles}/>
                    }
                </IconButton>
            </div>
        )
    }
    
    return (
        <div className={'header-container'}>
            {getMenuButton()}
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