import React, { Component } from 'react';
import { AuthTemplate } from 'common/components';
import './Login.scss';

class Login extends Component {
    render() {
        return (
            <AuthTemplate
                formTitle={'SIGN INTO YOUR ACCOUNT'}
                form={
                    <form>
                        <label>
                            Name:
                            <input type="text" name="name" />
                        </label>
                    </form>
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