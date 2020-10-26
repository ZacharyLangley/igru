import React from 'react';
import { node, oneOfType, string } from 'prop-types';
import { Card, Logo, Button } from 'common/components';
import { Link } from "react-router-dom";
import './AuthTemplate.scss';

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
                            <Link to={footerLinkUrl} className={'link'}>{footerLinkText}</Link>
                        </div>
                        <div className={'button-container'}>
                            <Button type="submit" onClick={onSubmit}>{buttonText}</Button>
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