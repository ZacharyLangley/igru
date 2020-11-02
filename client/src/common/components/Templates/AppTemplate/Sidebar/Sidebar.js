import React from 'react';
import { connect } from 'react-redux';
import { push } from 'connected-react-router';
import { bool, func } from 'prop-types';

import { toggleSidebar } from 'domain/actions/appActions';
import './Sidebar.scss';

const Sidebar = ({
    isSidebarOpen,
    push,
    toggleSidebar,
}) => {
    const openClassName = (this.props.isSidebarOpen) ? 'open' : 'closed'
    return <div className={`sidebar-container ${openClassName}`}>{'sidebar'}</div>
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