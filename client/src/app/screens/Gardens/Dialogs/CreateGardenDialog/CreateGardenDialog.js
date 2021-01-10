import React, {useState} from 'react';
import { connect } from 'react-redux'
import { push } from 'connected-react-router'

import CreateGardenForm from '../../Forms/CreateGardenForm/CreateGardenForm';
import { Dialog } from 'common/components';
import { makeStyles } from '@material-ui/core/styles';
import './CreateGardenDialog.scss';

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
                <CreateGardenForm onSubmit={handleSubmit}/>
            </div>
        </Dialog>
    )
}



export default CreateGarden;