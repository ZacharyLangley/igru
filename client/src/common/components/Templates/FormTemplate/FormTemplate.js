import React from 'react';
import { node, oneOfType, string } from 'prop-types';

import './FormTemplate.scss';

export const FormTemplate = ({leftFields, rightFields}) => {
    return (
        <div className={'form-template-container'}>
            {
                leftFields &&
                <div className={'form-left-field-container'}>{leftFields}</div>
            }
            {
                rightFields &&
                <div className={'form-right-field-container'}>{rightFields}</div>
            }
        </div>
    )
}

export default FormTemplate;

FormTemplate.propTypes = {
    leftFields: oneOfType([node, string]),
    rightFields: oneOfType([node, string])
}