import React, { Component, useState } from 'react';
import {FormTemplate} from 'common/components/Templates';
import {StringField} from 'common/components/Fields';
import './GardenForm.scss';

export const GardenForm = ({defaultData}) => {
    const [data, setData] = useState({
        name: undefined,
        comment: undefined,
        location: undefined,
        growSize: undefined,
        growStyle: undefined,
        growType: undefined,
        editors: undefined,
        tags: undefined,
        ...defaultData
    })

    const handleChange = (prop) => (event) => {
        setData({ ...data, [prop]: event.target.value });
    };

    const leftFields = () => {
        return (
            <>
                <StringField 
                    label="Name"
                    id="Name"
                    onChange={handleChange('name')}
                    error={data.name === ""}
                    helperText={data.name === "" ? 'Name field cannot be empty' : undefined }
                />
            </>
        )
    }
    
    const rightFields = () => {
        return (
            <StringField 
                label="Comment"
                id="Comment"
                onChange={handleChange('comment')}
                error={data.comment === ""}
                helperText={data.comment === "" ? 'Comment field cannot be empty' : undefined }
            />
        )
    }

    return <FormTemplate leftFields={leftFields()} rightFields={rightFields()}/>
}

export default GardenForm;