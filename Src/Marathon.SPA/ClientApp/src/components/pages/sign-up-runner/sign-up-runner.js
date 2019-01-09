import React, { Component } from 'react';

import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

import PageCaption from '../../controls/page-caption';

import './sign-up-runner.css';

export default class SugnUpRunner extends Component {

    constructor() {
        super();
        this.handleChange = this.handleChange.bind(this);
    }

    state = {
        startDate: null
    };

    handleChange(date) {
        this.setState({
            startDate: date
        });
    }

    pageCapion = {
        caption: "Регистрация бегуна",
        description: "Пожалуйста заполните всю информацию, чтобы зарегистрироваться в качестве бегуна"
    };  

    render()
    {
        return (
            <div>
                <PageCaption { ...this.pageCapion }/>
                <div className="container main-content">
                    <form id="signInForm">
                        <div className="row">
                            <div className="col-12 col-sm-6">
                                <div className="form-group row">
                                    <label htmlFor="emailEntry" className="col-sm-2 col-form-label">Email</label>
                                    <div className="col-sm-10">
                                        <input type="email" className="form-control" id="emailEntry" placeholder="Email" />
                                    </div>
                                </div>
                                <div className="form-group row">
                                    <label htmlFor="passwordEntry" className="col-sm-2 col-form-label">Пароль</label>
                                    <div className="col-sm-10">
                                        <input type="password" className="form-control" id="passwordEntry" placeholder="Пароль" />
                                    </div>
                                </div>
                                <div className="form-group row">
                                    <label htmlFor="confirmPasswordEntry" className="col-sm-2 col-form-label">Повторите пароль</label>
                                    <div className="col-sm-10">
                                        <input type="password" className="form-control" id="confirmPasswordEntry" placeholder="Повторите пароль" />
                                    </div>
                                </div>
                                <div className="form-group row">
                                    <label htmlFor="firstNameEntry" className="col-sm-2 col-form-label">Имя</label>
                                    <div className="col-sm-10">
                                        <input type="text" className="form-control" id="firstNameEntry" placeholder="Имя" />
                                    </div>
                                </div>
                                <div className="form-group row">
                                    <label htmlFor="lastNameEntry" className="col-sm-2 col-form-label">Фамилия</label>
                                    <div className="col-sm-10">
                                        <input type="text" className="form-control" id="lastNameEntry" placeholder="Фамилия" />
                                    </div>
                                </div>
                                <div className="form-group row">
                                    <label htmlFor="genderEntry" className="col-sm-2 col-form-label">Пол</label>
                                    <div className="col-sm-10">
                                        <select className="form-control" id="genderEntry">
                                            <option selected disabled>Пол</option>
                                            <option>Мужской</option>
                                            <option>Женский</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div className="col-12 col-sm-6">
                                <div className="card">
                                    <img className="card-img-top" alt="Фото профиля" />
                                    <div className="card-body">
                                        <div className="input-group">
                                            <div className="custom-file">
                                                <input type="file" className="custom-file-input" id="photoEntry" aria-describedby="Фото файл"/>
                                                <label className="custom-file-label" for="photoEntry">Выберите фото</label>
                                            </div>
                                        </div>
                                        <div className="form-group row">
                                            <label htmlFor="dateEntry" className="col-sm-4 col-form-label">Дата рождения</label>
                                            <div className="col-sm-8">
                                                <DatePicker
                                                    className="datePicker"
                                                    selected={ this.state.startDate }
                                                    onChange={ this.handleChange }
                                                    dateFormat="DD.MM.YYYY"
                                                    placeholderText="Дата рождения"
                                                    id="dateEntry"/>
                                            </div>
                                        </div>
                                        <div className="form-group row">
                                            <label htmlFor="countryEntry" className="col-sm-2 col-form-label">Страна</label>
                                            <div className="col-sm-10">
                                                <select className="form-control" id="countryEntry">
                                                    <option selected disabled>Страна</option>
                                                    <option>Россия</option>
                                                    <option>Беларусь</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
                <div className="container row bottom-content">
                    <div className="col">
                        <button className="btn float-right" form="signInForm">Отмена</button>
                    </div>
                    <div className="col">
                        <button className="btn float-left" form="signInForm">Регистрация</button>
                    </div>
                </div>
            </div>        
        );
    }
}