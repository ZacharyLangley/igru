import React from 'react';

import './Form.scss';

const Form = ({formProps, children}) => {
    return (
        <form noValidate autoComplete="on" {...formProps}>
            {children}
        </form>
    )
}

export default Form;