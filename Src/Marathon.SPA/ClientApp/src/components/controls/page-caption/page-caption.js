import React from 'react';

import './page-caption.css';

const PageCaption = ({ caption, description }) =>  {

    return (
        <div className="container-fluid page-caption">
            <p className="caption">{ caption }</p>
            <p className="description">{ description }</p>
        </div>
    );    
};

export default PageCaption;