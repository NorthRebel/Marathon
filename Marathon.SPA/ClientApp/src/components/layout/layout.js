import React, { Component } from 'react';

import { TitleBar, BottomBar, MainTitleBar } from '../controls/bars';
import { MainPage, CheckRunner, SignInPage } from '../pages';

import './layout.css';

export default class Layout extends Component {

    render() {
        return (
            <div>
                <MainTitleBar />
               
                <div className="container-fluid">
                    <SignInPage />
                </div>
                
                <div className="footer">
                    <BottomBar />
                </div>
            </div>
        );
    }
}