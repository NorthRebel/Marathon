import React from 'react';

import './check-runner.css';

const CheckRunner = () => {
    return (
        <div className="col-lg-6 offset-lg-3 col-sm-8 offset-sm-2 col-xs-12">
            <button className="btn btn-block btn-lg">Я участвовал ранее</button>
            <button className="btn btn-block btn-lg">Я новый участник</button>
        </div>
    );
};

export default CheckRunner;