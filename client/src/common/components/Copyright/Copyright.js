import React from 'react';
import CopyrightIcon from '@material-ui/icons/Copyright';

import './Copyright.scss';

export const Copyright = () => {
    return (
        <div className={'copyright-container'}>
            <div className={'icon'}>
                <CopyrightIcon />
            </div>
            <div className={'label'}>{'MIT License - iGru - 2020'}</div>
        </div>
    )
}

export default Copyright;