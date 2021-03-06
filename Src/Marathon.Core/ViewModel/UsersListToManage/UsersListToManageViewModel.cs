﻿using System;
using System.Windows.Input;
using Marathon.Core.Models;
using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.PageCaption;
using Marathon.Core.ViewModel.UsersListToManage.Models;
using Marathon.Core.ViewModel.UsersListToManage.UsersList;

namespace Marathon.Core.ViewModel.UsersListToManage
{
    /// <summary>
    /// The view model for a users list to manage page
    /// </summary>
    public class UsersListToManageViewModel : SignedInViewModel
    {
        #region Public Properties

        /// <summary>
        /// List of user's types of privileges
        /// </summary>
        public IEnumerable<string> UserTypes { get; set; }

        /// <summary>
        /// Selected user type
        /// </summary>
        public string UserType { get; set; }

        /// <summary>
        /// Attributes of users list for <see cref="SortCommand"/>
        /// </summary>
        public IEnumerable<string> AttributesToSort { get; set; }

        /// <summary>
        /// Selected attribute to sort list of users
        /// </summary>
        public string AttributeToSort { get; set; }

        /// <summary>
        /// Request which contains values to search user by any attribute of <see cref="UsersListItemViewModel"/> for <see cref="SearchCommand"/>
        /// </summary>
        public string SearchRequest { get; set; }

        /// <inheritdoc cref="UsersListViewModel"/>
        public UsersListViewModel Users { get; set; }

        /// <inheritdoc cref="ManageUsersCondition"/> for <see cref="FindCommand"/>
        public ManageUsersCondition UsersCondition { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Sort users by selected attribute
        /// </summary>
        public ICommand SortCommand { get; set; }

        /// <summary>
        /// Find user from <see cref="Users"/> by any attribute of <see cref="UsersListItemViewModel"/>
        /// </summary>
        public ICommand SearchCommand { get; set; }

        // <summary>
        /// Find users form <see cref="Users"/> by <see cref="UsersCondition"/>
        /// </summary>
        public ICommand FindCommand { get; set; }

        /// <summary>
        /// Sign up new user
        /// </summary>
        public ICommand AddNewUserCommand { get; set; }

        #endregion

        #region Constructor

        public UsersListToManageViewModel()
        {
            PageCaption = new PageCaptionViewModel("Управление пользователями");

            UsersCondition = new ManageUsersCondition();
            Users = new UsersListViewModel();

            SortCommand = new RelayCommand(SortUsers);
            FindCommand = new RelayCommand(FindUsers);
            SearchCommand = new RelayCommand(SearchUser);
            AddNewUserCommand = new RelayCommand(x => GoToPage(ApplicationPage.AddUser));
        }

        #endregion

        #region Command Helpers

        private void SortUsers(object obj)
        {
            throw new NotImplementedException();
        }

        private void FindUsers(object obj)
        {
            throw new NotImplementedException();
        }

        private void SearchUser(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
