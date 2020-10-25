import React, { Component } from 'react';
import { AuthTemplate, Form, PasswordField, StringField } from 'common/components';
import './Login.scss';

class Login extends Component {
    render() {
        return (
            <AuthTemplate
                formTitle={'SIGN INTO YOUR ACCOUNT'}
                form={
                    <Form>
                        <StringField label="Username" id="Username"/>
                        <PasswordField label="Password" id="Password"/>
                    </Form>
                }
                footerText={'Need an account?'}
                footerLinkUrl={'#'}
                footerLinkText={'Click here.'}
                buttonText={'SUBMIT'}
                onSubmit={() => console.log('Login Submit')}
            />
        )
    }
}

export default Login;