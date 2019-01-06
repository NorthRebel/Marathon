import React from 'react';

import './title-bar.css';

const TitleBar = () => {
    return (
        <div className="container-fluid">
            <div className="row title-bar">
                <div className="col-xs-1">
                    <button className="btn">Назад</button>
                </div>
                <div className="col-xs-11">
                    <p>MARATHON SKILLS 2019</p>
                </div>
            </div>
        </div>
    );
};

export default TitleBar;