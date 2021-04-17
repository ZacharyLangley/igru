import React from 'react';

import MaterialDialogTitle from '@material-ui/core/DialogTitle';
import MaterialDialog from '@material-ui/core/Dialog';
import MaterialDialogActions from '@material-ui/core/DialogActions';
import MaterialDialogContent from '@material-ui/core/DialogContent';
import { Button } from 'common/components';

import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles({
    dialogContent: {
        minWidth: '500px',
        minHeight: '200px',
        padding: '16px 24px' 
    },
    dialogFooter: {
        padding: 24
    }
});

function Dialog({
    title,
    onClose,
    open,
    actions,
    ...props
}) {
    const classes = useStyles();

    return (
      <MaterialDialog
        disableBackdropClick
        maxWidth={'md'}
        onClose={onClose}
        aria-labelledby="dialog-title"
        open={open}>
        <MaterialDialogTitle id="dialog-title">{title}</MaterialDialogTitle>
        <MaterialDialogContent>
            {props.children}
        </MaterialDialogContent>
        {
            actions &&
            <MaterialDialogActions className={classes.dialogFooter}>
                <Button className={'cancel'} variant="text" onClick={onClose} color="primary">
                    {'Cancel'}
                </Button>
                <Button onClick={onClose} color="primary">
                    {'Submit'}
                </Button>
            </MaterialDialogActions>
        }
      </MaterialDialog>
    );
  }

  export default Dialog;