import React from 'react';
import { Grid, Row, Col, Button } from 'react-bootstrap';

import './title-bar.css';

const TitleBar = () => {
    return (
        <Grid fluid>
            <Row className="title-bar">
                <Col xs={1}>
                    <Button variant="secondary">Назад</Button>
                </Col>
                <Col xs={11}>
                    <p>MARATHON SKILLS 2019</p>
                </Col>
            </Row>
        </Grid>
    );
};

export default TitleBar;