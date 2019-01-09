import React from 'react';

import './main-page.css';

const MainPage = () => {
    return (
        <div className="container-fluid main-content">
            <div className="col-lg-6 offset-lg-3 col-sm-8 offset-sm-2 col-xs-12">
                <button className="btn btn-block">Я хочу стать бегуном</button>
                <button className="btn btn-block">Я хочу стать спонсором бегуна</button>
                <button className="btn btn-block">Я хочу узнать больше о событии</button>            
            </div>
        </div>
    );
};

export default MainPage;