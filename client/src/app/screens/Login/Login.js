import React, { useState } from 'react';
import { connect } from 'react-redux'
import { push } from 'connected-react-router'
import { signinUser } from 'domain/actions/authActions'
import { AuthTemplate, Form, PasswordField, StringField } from 'common/components';

import './Login.scss';

const Login = ({
    signinUser,
    push
}) => {
    const [values, setValues] = useState({
        email: undefined,
        password: undefined,
        showPassword: false
    })
    
    const handleChange = (prop) => (event) => {
        setValues({ ...values, [prop]: event.target.value });
    };

    const handleClickShowPassword = () => {
        setValues({ ...values, showPassword: !values.showPassword });
    };

    return (
        <AuthTemplate
            formTitle={'SIGN INTO YOUR ACCOUNT'}
            form={
                <Form>
                    <StringField 
                        label="Email"
                        id="Email"
                        onChange={handleChange('email')}
                        error={values.email === ""}
                        helperText={values.email === "" ? 'Email field cannot be empty' : undefined }
                    />
                    <PasswordField
                        showPassword={values.showPassword} 
                        onChange={handleChange('password')}
                        handleClickShowPassword={handleClickShowPassword}
                        error={values.password === ""}
                        helperText={values.password === "" ? 'Password field cannot be empty' : undefined }
                    />
                </Form>
            }
            footerText={'Need an account?'}
            footerLinkUrl={'/Register'}
            footerLinkText={'Click here.'}
            buttonText={'SUBMIT'}
            onSubmit={() => { 
                console.log('Login Submit');
                signinUser(values.email, values.password, push);
            }}
        />
    )
}

const mapStateToProps = (state) => ({

})

const mapDispatchToProps = {
    signinUser,
    push
}


export default connect(mapStateToProps, mapDispatchToProps)(Login)