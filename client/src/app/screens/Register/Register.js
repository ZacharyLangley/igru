import React, { useState } from 'react';
import { connect } from 'react-redux'
import { push } from 'connected-react-router'
import { registerUser } from 'domain/actions/authActions'
import { AuthTemplate, Form, PasswordField, StringField } from 'common/components';

import './Register.scss';
import { FlashOnRounded } from '@material-ui/icons';

const Register = ({
    registerUser,
    push
}) => {
    const [values, setValues] = useState({
        email: undefined,
        displayName: undefined,
        username: undefined,
        password: undefined,
        confirmPassword: undefined,
        showPassword: false,
        showConfirmPassword: false
    })
    
    const handleChange = (prop) => (event) => {
        setValues({ ...values, [prop]: event.target.value });
    };

    const handleClickShowPassword = () => {
        setValues({ ...values, showPassword: !values.showPassword });
    };

    const handleClickShowConfirmPassword = () => {
        setValues({ ...values, showConfirmPassword: !values.showConfirmPassword });
    };

    return (
        <AuthTemplate
            formTitle={'CREATE A NEW ACCOUNT'}
            form={
                <Form>
                    <StringField 
                        label="Email"
                        id="Email"
                        onChange={handleChange('email')}
                        error={values.email === ""}
                        helperText={values.email === "" ? 'Email field cannot be empty' : undefined }
                    />
                    <StringField 
                        label="Username"
                        id="Username"
                        onChange={handleChange('username')}
                        error={values.email === ""}
                        helperText={values.email === "" ? 'Username field cannot be empty' : undefined }
                    />
                    <StringField 
                        label="Display Name"
                        id="Display Name"
                        onChange={handleChange('displayName')}
                        error={values.email === ""}
                        helperText={values.email === "" ? 'Dislpay Name field cannot be empty' : undefined }
                    />
                    <PasswordField
                        showPassword={values.showPassword} 
                        onChange={handleChange('password')}
                        handleClickShowPassword={handleClickShowPassword}
                        error={values.password === ""}
                        helperText={values.password === "" ? 'Password field cannot be empty' : undefined }
                    />
                    <PasswordField
                        label={'Confirm Password'}
                        id={'Confirm Password'}
                        showPassword={values.showConfirmPassword} 
                        onChange={handleChange('confirmPassword')}
                        handleClickShowPassword={handleClickShowConfirmPassword}
                        error={values.confirmPassword === ""}
                        helperText={values.confirmPassword === "" ? 'Confirm Password field cannot be empty' : undefined }
                    />
                </Form>
            }
            footerText={'Already have an account?'}
            footerLinkUrl={'/Login'}
            footerLinkText={'Click here.'}
            buttonText={'SUBMIT'}
            onSubmit={() => { 
                console.log('Register User Submit');
                registerUser(values.email, values.username, values.displayName, values.password, push);
            }}
        />
    )
}

const mapStateToProps = (state) => ({

})

const mapDispatchToProps = {
    registerUser,
    push
}


export default connect(mapStateToProps, mapDispatchToProps)(Register)