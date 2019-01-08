import React from 'react';

import PageCaption from '../../controls/page-caption';

import './sign-up-to-marathon.css';

const SignUpRunnerToMarathon = () => {

    const pageCapion = {
        caption: "Регистрация на марафон",
        description: "Пожалуйста, заполните всю информацию, чтобы зарегистрироваться на Skills Marathon 2016 проводимом в Москве. Россия. " +
                     "С вами свяжутся после регистрации, для уточнения оплаты и другой информации."
    }; 

    return (
        <div>
            <PageCaption { ...pageCapion }/>
            <div className="container main-content">
            <form id="signUpToMarathonForm">
                <div className="row">
                    <div className="col-12 col-sm-6">
                        <div className="card">
                            <div className="card-body">
                                <h2 className="card-title">Вид марафона</h2>
                                <div className="form-check">
                                    <input className="form-check-input" type="checkbox" value="" id="ch1" />
                                    <label className="form-check-label" htmlFor="ch1">
                                        42km Полный марафон($145)
                                    </label>
                                </div>
                                <div className="form-check">
                                    <input className="form-check-input" type="checkbox" value="" id="ch2" />
                                    <label className="form-check-label" htmlFor="ch2">
                                        21km Полумарафон ($75)
                                    </label>
                                </div>
                                <div className="form-check">
                                    <input className="form-check-input" type="checkbox" value="" id="ch3" />
                                    <label className="form-check-label" htmlFor="ch3">
                                        5km Малая дистанция ($20)
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-body">
                                <h2 className="card-title">Детали спонсорства</h2>
                                <div className="form-group row">
                                    <label htmlFor="charitySelect" className="col-sm-2 col-form-label">Взнос</label>
                                    <div className="col-sm-10">
                                        <select className="form-control" id="charitySelect">
                                            <option selected>Фонд 1</option>
                                            <option>Фонд 2</option>
                                            <option>Фонд 3</option>
                                        </select>
                                    </div>
                                </div>
                                <div className="form-group row">
                                    <label htmlFor="amountEntry" className="col-sm-2 col-form-label">Сумма взноса</label>
                                    <div className="col-sm-10">
                                        <input type="text" className="form-control" id="amountEntry" placeholder="500$" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="row confirm-div">
                            <div className="col">
                                <button className="btn float-right" form="signInForm">Отмена</button>
                            </div>
                            <div className="col">
                                <button className="btn float-left" form="signInForm">Регистрация</button>
                            </div>
                        </div>
                    </div>
                    <div className="col-12 col-sm-6">
                        <div className="card">
                            <div className="card-body">
                                <h2 className="card-title">Варианты комплектов</h2>
                                <div className="form-check">
                                    <input className="form-check-input" type="radio" name="raceKit" value="" id="rk1" />
                                    <label claclassNamess="form-check-label" htmlFor="rk1">
                                        Вариант A ($0): Номер бегуна+ RFID браслет
                                    </label>
                                </div>
                                <div className="form-check">
                                    <input className="form-check-input" type="radio" name="raceKit" value="" id="rk2" />
                                    <label claclassNamess="form-check-label" htmlFor="rk2">
                                        Вариант B ($20): вариант A + бейсболка + бутылка воды
                                    </label>
                                </div>
                                <div className="form-check">
                                    <input className="form-check-input" type="radio" name="raceKit" value="" id="rk3" />
                                    <label claclassNamess="form-check-label" htmlFor="rk3">
                                        Вариант C ($45): Вариант B +футболка + сувенирный буклет
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-body">
                                <h2 className="card-title">Регистрационный взнос</h2>
                                <h1>500$</h1>
                            </div>
                        </div>       
                    </div>
                </div>
                </form>    
            </div>
        </div>
    );
};

export default SignUpRunnerToMarathon;