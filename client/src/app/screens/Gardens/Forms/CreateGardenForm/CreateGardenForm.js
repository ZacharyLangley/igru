import React, { Component, createRef } from 'react';
import './CreateGardenForm.scss';

class CreateGardenForm extends Component {
    constructor(props){
        super(props);
        this.formRef = createRef();
    }

    onSubmit = () => {
        this.props.onSubmit(this.formRef)
    }

    render(){
        return (
            <form onSubmit={this.onSubmit} ref={this.formRef}>

            </form>
        )
    }
}

export default CreateGardenForm;