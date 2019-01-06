import React, { Component } from 'react';

import { TitleBar, BottomBar, MainTitleBar } from '../controls/bars';
import { MainPage, CheckRunner, SignInPage, SugnUpRunner } from '../pages';

import './layout.css';

export default class Layout extends Component {

    render() {
        return (
            <div>
                <TitleBar />
               
                <div className="container-fluid">
                    <SugnUpRunner />
                </div>
                
                <div className="footer">
                    <BottomBar />
                </div>
            </div>
        );
    }
}