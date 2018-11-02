using System;
using System.Collections.Generic;
using System.Windows.Input;
using Marathon.Core.Models;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Input;
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
        public EntryViewModel<IEnumerable<string>> UserTypes { get; set; }

        /// <summary>
        /// Attributes of users list for <see cref="SortCommand"/>
        /// </summary>
        public EntryViewModel<IEnumerable<string>> AttributesToSort { get; set; }

        /// <summary>
        /// Request which contains values to search user by any attribute of <see cref="UsersListItemViewModel"/> for <see cref="SearchCommand"/>
        /// </summary>
        public EntryViewModel<string> SearchRequest { get; set; }

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
            PageCaption = new PageCaptionViewModel
            {
                Caption = "Управление пользователями"
            };

            UserTypes = new EntryViewModel<IEnumerable<string>>("Фильтр по ролям");
            AttributesToSort = new EntryViewModel<IEnumerable<string>>("Сортировать по");
            SearchRequest = new EntryViewModel<string>("Поиск");

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
