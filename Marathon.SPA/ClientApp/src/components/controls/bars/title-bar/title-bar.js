import React, { Component } from 'react';

import './title-bar.css';

export default class TitleBar extends Component {

    state = {
        goBackEnabled: true,
        logoutVisible: false
    };
    
    render() {
        
        const { goBackEnabled, logoutVisible } = this.state;
        
        const logoutButton = logoutVisible ? (
            <div className="col-md-auto">
                <button className="btn">Выход</button>
            </div>
        ) : null;
        
        return (
            <div className="container-fluid">
                <div className="row title-bar">
                    <div className="col-md-auto">
                        <button className="btn" disabled={ !goBackEnabled }>Назад</button>
                    </div>
                    <div className="col">
                        <h1>MARATHON SKILLS 2019</h1>
                    </div>
                    { logoutButton }
                </div>
            </div>
        );
    }
};