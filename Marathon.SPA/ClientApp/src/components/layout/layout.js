import React, { Component } from 'react';

import { TitleBar, BottomBar, MainTitleBar } from '../controls/bars';
import { MainPage, CheckRunner } from '../pages';

import './layout.css';

export default class Layout extends Component {

    render() {
        return (
            <div>
                <MainTitleBar />
               
                <div className="container-fluid main-content">
                    <MainPage />
                </div>
                
                <div className="footer">
                    <BottomBar />
                </div>
            </div>
        );
    }
}