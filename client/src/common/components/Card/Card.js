import React from 'react';
import './Card.scss';

const Card = ({ header, body, footer }) => (
    <div className={'card-container'}>
        {
            header &&
            <div className={'card-header'}>{header}</div>
        }
        {
            body &&
            <div className={'card-body'}>{body}</div>
        }
        {
            footer &&
            <div className={'card-footer'}>{footer}</div>
        }
    </div>
)

export default Card;