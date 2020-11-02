import React from 'react';
import { node } from 'prop-types';

import Header from './Header/Header';
import Sidebar from './Sidebar/Sidebar';
import './AppTemplate.scss';

const AppTemplate = ({ body }) => (
    <div className={'app-template-container'}>
        <Header />
        <Sidebar />
        <div className={'app-template-body'}>
            {body}
        </div>
    </div>
)


AppTemplate.propTypes = {
    body: node
}

export default AppTemplate