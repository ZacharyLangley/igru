import React from 'react';
import TextField from '@material-ui/core/TextField';

import './PasswordField.scss';

const styles = { 
    width: '100%',
    marginBottom: '24px'
};

const PasswordField = (props) => {
    return (
        <TextField
            type="password"
            autoComplete="current-password"
            variant="outlined"
            style={styles}
            {...props}
        />
    )
}

export default PasswordField;