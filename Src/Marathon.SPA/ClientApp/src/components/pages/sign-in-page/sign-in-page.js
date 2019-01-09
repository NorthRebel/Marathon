import React from 'react';

import PageCaption from '../../controls/page-caption';

import './sign-in-page.css';

const SignInPage = () => {

    const pageCapion = {
        caption: "Форма авторизации",
        description: "Пожалуйста, авторизуйтесь в системе, используя ваш адрес электронной почты и пароль"
    }

    return (
        <div>
            <PageCaption { ...pageCapion }/>
            <div className="container main-content">
                <form>
                    <div className="form-group row">
                        <label htmlFor="emailEntry" className="col-sm-2 col-form-label">Email</label>
                        <div className="col-sm-10">
                            <input type="email" className="form-control" id="emailEntry" 
                                placeholder="Введите свой email" />
                        </div>
                    </div>
                    <div className="form-group row">
                        <label htmlFor="passwordEntry" className="col-sm-2 col-form-label">Пароль</label>
                        <div className="col-sm-10">
                            <input type="password" className="form-control" id="passwordEntry" placeholder="Введите свой пароль" />
                        </div>
                    </div>
                    <div className="row">
                        <div className="col">
                            <button className="btn btn-block">Отмена</button>
                        </div>
                        <div className="col">
                            <button type="submit" className="btn btn-block">Вход</button>
                        </div>                    
                    </div>                
                </form>
            </div>
        </div>        
    );
};

export default SignInPage;