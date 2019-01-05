import React, { Component } from 'react';

import { TitleBar, BottomBar, MainTitleBar } from '../controls/bars';
import { MainPage } from '../pages';

import './layout.css';

export default class Layout extends Component {

    render() {
        return (
            <div>
                <MainTitleBar />
                <MainPage />
                <div className="navbar-fixed-bottom default-footer">
                    <BottomBar />
                </div>
            </div>
        );
    }
}