import React from 'react';
import Radio from '@material-ui/core/Radio';
import MaterialRadioGroup from '@material-ui/core/RadioGroup';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import FormControl from '@material-ui/core/FormControl';
import FormLabel from '@material-ui/core/FormLabel';


const mapRadiobuttons = (radioButtons=[]) => {
    return radioButtons.map((button, index) => {
        return (
            <FormControlLabel
                key={index}
                value={button.value}
                control={<Radio size={'small'} color="primary" />}
                label={button.label}
                labelPlacement="end"
            />
        )
    })
}

const RadioGroup = ({
    defaultValue,
    value,
    ariaLabel,
    name,
    label,
    onChange,
    radioButtons
}) => {

    return (
        <FormControl component="fieldset">
        <FormLabel component="legend">{label}</FormLabel>
            <MaterialRadioGroup 
                row 
                defaultValue={defaultValue}
                aria-label={ariaLabel}
                name={name}
                value={value}
                onChange={onChange}>
                {mapRadiobuttons(radioButtons)}
            </MaterialRadioGroup>
        </FormControl>
    );
}

export default RadioGroup;