import React from 'react';
import logo from 'common/assets/IGRU_White_logo.png';
import { oneOfType, number, string } from 'prop-types';
import './Logo.scss';

const Logo = ({height, width, textSize}) => (
    <div className={'logo-container'}>
        <div className={'logo'}>
            <img 
                src={logo}
                alt={'IGRU_LOGO'} 
                height={height || 100}
                width={width || 100}
            />
        </div>
        <div className={`name ${textSize || 'default'}`}>IGRU</div>
    </div>
);

Logo.propTypes = {
    height: oneOfType([number, string]),
    width: oneOfType([number, string]),
    textSize: string
}

export default Logo