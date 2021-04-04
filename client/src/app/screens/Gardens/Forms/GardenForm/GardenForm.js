import React, { Component, useState } from 'react';
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
    return <div>Garden Form</div>
}

export default GardenForm;