import React from 'react';
import TextField from '@material-ui/core/TextField';
import SearchIcon from '@material-ui/icons/Search';
import InputAdornment from '@material-ui/core/InputAdornment';
import { makeStyles } from '@material-ui/core/styles';

import './SearchField.scss';
import Button from 'common/components/Button/Button';

const useStyles = makeStyles((theme) => ({
    field: {
        margin: theme.spacing(1),
    },
    button: {
        margin: theme.spacing(1),
    },
}));

const SearchField = ({
    onChange,
    onSubmit,
    textFieldProps,
    buttonProps
}) => {

    const classes = useStyles();

    return (
        <div className={'search-field-container'}>
            <TextField
                id={'search'}
                onChange={onChange}
                variant="outlined"
                size={'small'}
                className={classes.field}
                InputProps={{
                    startAdornment: (
                      <InputAdornment position="start">
                        <SearchIcon />
                      </InputAdornment>
                    ),
                  }}
                {...textFieldProps}/>
            <Button
                size={'normal'}
                className={classes.field}
                onClick={onSubmit}
                {...buttonProps}>
                    {'Search'}
            </Button>
        </div>
    )
}

export default SearchField;