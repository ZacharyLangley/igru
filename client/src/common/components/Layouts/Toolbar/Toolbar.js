import React from 'react';
import { node } from 'prop-types';
import './Toolbar.scss';

const Toolbar = ({ left, right }) => (
    <div className={'toolbar-container'}>
        { left && <div className={'left'}>{left}</div> }
        { right && <div className={'right'}>{right}</div> }
    </div>
)

Toolbar.propTypes = {
    left: node,
    right: node
}

export default Toolbar;