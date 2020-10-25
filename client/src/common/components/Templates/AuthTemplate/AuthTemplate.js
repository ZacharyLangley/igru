import React from 'react';
import { node, oneOfType, string } from 'prop-types';
import './AuthTemplate.scss';
import { Card, Logo, Button } from 'common/components';

const AuthLayout = ({
    form,
    formTitle,
    footerText,
    footerLinkUrl,
    footerLinkText,
    buttonText,
    onSubmit
}) => (
    <div className={'auth-layout-container'}>
        <div className={'auth-content'}>
            <Card
                header={<Logo />}
                body={
                    <div className={'form-container'}>
                        <div className={'form-title'}>{formTitle}</div>
                        <div className={'form-container'}>
                            {form}
                        </div>
                    </div>
                }
                footer={
                    <div className={'footer-container'}>
                        <div className={'link-container'}>
                            <span className={'title'}>{footerText}</span>
                            <a href={footerLinkUrl} className={'link'}>{footerLinkText}</a>
                        </div>
                        <div className={'button-container'}>
                            <Button onClick={onSubmit}>{buttonText}</Button>
                        </div>
                    </div>
                }
            />
        </div>
    </div>
)

export default AuthLayout;

AuthLayout.propTypes = {
    form: oneOfType([node, string])
}