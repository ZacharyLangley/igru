import React from 'react'
import { node, oneOfType, string, array } from 'prop-types';
import './DashboardTemplate.scss';

const mapModules = (modules) => modules.length ? modules.map(module => module) : modules

const DashboardTemplate = props => (
    <div className={'dashboard-template-container'}>
        <div className={'prime-content'}>
            { 
                props.top && 
                <div className={'top-content'}>{mapModules(props.top)}</div>
            }
            { 
                props.bottom &&
                <div className={'bottom-content'}>{mapModules(props.bottom)}</div>
            }
        </div>
    </div>
)

DashboardTemplate.propTypes = {
    top: oneOfType([array, node, string]),
    bottom: oneOfType([array, node, string])
}

export default DashboardTemplate;