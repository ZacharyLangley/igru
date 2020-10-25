import React from 'react';
import TextField from '@material-ui/core/TextField';
import './StringField.scss';

const styles = { 
    width: '100%',
    marginBottom: '24px'
};

const StringField = (props) => {
    return (
        <TextField variant="outlined" style={styles} {...props}/>
    )
}

export default StringField;