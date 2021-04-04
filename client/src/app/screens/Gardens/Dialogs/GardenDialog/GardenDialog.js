import React, {useState} from 'react';
import { connect } from 'react-redux'
import { push } from 'connected-react-router'

import GardenForm from '../../Forms/GardenForm/GardenForm';
import { Dialog } from 'common/components';
import { makeStyles } from '@material-ui/core/styles';
import './GardenDialog.scss';

const useStyles = makeStyles({
    dialogContent: {
        minWidth: '500px',
        minHeight: '200px',
    }
});

const CreateGarden = ({
    title,
    onClose,
    open,
    content,
    ...props
}) => {
    const classes = useStyles();

     const handleSubmit = (event) => {
        event.preventDefault();
    }

    return (
        <Dialog
            open={open}
            onClose={onClose}
            title={'Create Garden'}
            actions={true}>
            <div className={classes.dialogContent}>
               {content}
            </div>
        </Dialog>
    )
}



export default CreateGarden;