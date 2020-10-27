import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import MaterialButton from '@material-ui/core/Button';
import MaterialIconButton from '@material-ui/core/IconButton';

const useStyles = makeStyles({
    root: {
      background: '#4eae53',
    },
  });

  export const IconButton = (props) => {
  return <MaterialIconButton {...props}>{props.children}</MaterialIconButton>
  }

const Button = (props) => {
    const classes = useStyles();
    return <MaterialButton className={classes.root} variant="contained" color="primary" {...props} >{props.children}</MaterialButton>
}

export default Button;