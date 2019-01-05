import React from 'react';
import { Grid, Col, Button } from 'react-bootstrap';

import './main-page.css';

const MainPage = () => {
    return (
        <Grid bsClass>
            <Col lg={6} lgOffset={3}>
                <Button block bsSize="large">Я хочу стать бегуном</Button>
                <Button block bsSize="large" >Я хочу стать спонсором бегуна</Button>
                <Button block bsSize="large">Я хочу узнать больше о событии</Button>
            </Col>
        </Grid>
    );
};

export default MainPage;