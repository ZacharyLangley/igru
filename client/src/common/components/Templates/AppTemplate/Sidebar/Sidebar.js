import React from 'react';
import { connect } from 'react-redux';
import { push } from 'connected-react-router';
import { bool, func } from 'prop-types';
import CloseIcon from '@material-ui/icons/Close';

import { IconButton, Copyright } from 'common/components';
import logo from 'common/assets/IGRU_White_logo_mini.png';
import { toggleSidebar } from 'domain/actions/appActions';
import sidebarOptions from './sidebarOptions';
import './Sidebar.scss';

const Sidebar = ({
    isSidebarOpen,
    push,
    toggleSidebar,
}) => {

    const sidebarContent = () => {
        return (
            <div className={'sidebar-content'}>
                {getHeader()}
                {getBody()}
                {getFooter()}
            </div>
        )
    }

    const getHeader = () => {
        return (
            <div className={'siderbar-header'}>
                <div className={'branding'} onClick={onLogoClick}>
                    <img className={'icon'} alt={'branding_icon'} src={logo} />
                    <span className={'name'}>{'IGRU'}</span>
                </div>
                <div className={'close-button'} onClick={toggleSidebar}>
                    <IconButton>
                        <CloseIcon />
                    </IconButton>
                </div>
            </div>
        );
    }
        
    const onLogoClick = () => {
        push('/')
        toggleSidebar();
    }
    
    const getBody = () => {
        return (
            <div className={'sidebar-options-container'}>
                {getSidebarOptions(sidebarOptions)}
            </div>
        );
    }
    
    const getSidebarOptions = (items) => {
        return items.map((item, index) => {
            return (
                <div className={'sidebar-option'} key={index} onClick={() => onOptionSelect(item.path)}>
                    {item.icon}
                    <span className={'label'}>{item.label}</span>
                </div>
            )
        });
    }

    const onOptionSelect = (path) => {
        push(path);
        toggleSidebar();
    }

    const getFooter = () => {
        return (
            <div className={'sidebar-footer'}>
                <Copyright />
            </div>
        );
    }

    const openClassName = (isSidebarOpen) ? 'open' : 'closed'
    return <div className={`sidebar-container ${openClassName}`}>{sidebarContent()}</div>
}

const mapStateToProps = (state) => ({
    isSidebarOpen: state.app.isSidebarOpen
})

const mapDispatchToProps = {
    toggleSidebar, push
}

Sidebar.propTypes = {
    isSidebarOpen: bool,
    toggleSidebar: func,
    push: func
}

export default connect(mapStateToProps, mapDispatchToProps)(Sidebar)