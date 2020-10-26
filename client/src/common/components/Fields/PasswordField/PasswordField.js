import React from 'react';
import TextField from '@material-ui/core/TextField';
import InputAdornment from '@material-ui/core/InputAdornment';
import IconButton from '@material-ui/core/IconButton';
import Visibility from '@material-ui/icons/Visibility';
import VisibilityOff from '@material-ui/icons/VisibilityOff';

import './PasswordField.scss';

const styles = { 
    width: '100%',
    marginBottom: '24px'
};

const handleMouseDownPassword = (event) => {
    event.preventDefault();
};

const PasswordField = ({
    showPassword,
    onChange,
    handleClickShowPassword,
    error,
    helperText,
    textFieldProps
}) => {
    return (
        <TextField
            label="Password"
            id="Password"
            type={showPassword ? 'text' : 'password'}
            autoComplete="current-password"
            variant="outlined"
            style={styles}
            onChange={onChange}
            error={error}
            helperText={helperText}
            InputProps={{
                endAdornment: 
                    <InputAdornment position="end">
                      <IconButton
                        aria-label="toggle password visibility"
                        onClick={handleClickShowPassword}
                        onMouseDown={handleMouseDownPassword}
                      >
                        {showPassword ? <Visibility /> : <VisibilityOff />}
                      </IconButton>
                    </InputAdornment>
            }}
            {...textFieldProps}
        />
    )
}

export default PasswordField;