import React from 'react';
import { Grid } from 'react-bootstrap';

import './main-title-bar.css';

const MainTitleBar = () => {
    return (
        <Grid bsClass>
            <div className="main-title-bar">
                <h1><strong>MARATHON SKILLS 2019</strong></h1>
                <div><em>Москва, Россия</em></div>
                <div><em>Пятница, 5 Января 2019</em></div>
            </div>
        </Grid>
    );
};

export default MainTitleBar;