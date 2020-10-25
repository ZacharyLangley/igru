import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import './StringField.scss';

const StringField = (props) => {
    return (
        <TextField variant="outlined" style={{ width: '100%' }} {...props}/>
    )
}

export default StringField;