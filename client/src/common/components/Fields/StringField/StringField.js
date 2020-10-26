import React from 'react';
import TextField from '@material-ui/core/TextField';
import './StringField.scss';

const styles = { 
    width: '100%',
    marginBottom: '24px'
};

const StringField = ({
    id,
    label,
    onChange,
    error,
    helperText,
    textFieldProps
}) => {
    return (
        <TextField
            id={id}
            label={label}
            onChange={onChange}
            error={error}
            helperText={helperText}
            variant="outlined" 
            style={styles} 
            {...textFieldProps}/>
    )
}

export default StringField;