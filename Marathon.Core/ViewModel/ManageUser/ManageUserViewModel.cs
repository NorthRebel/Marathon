using System;
using System.Windows.Input;
using Marathon.Core.Models;
using System.Threading.Tasks;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Input;
using Marathon.Core.ViewModel.PageCaption;
using Marathon.Core.ViewModel.ManageUser.Models;

namespace Marathon.Core.ViewModel.ManageUser
{
    /// <summary>
    /// The view model for a manage user page for add/edit user
    /// </summary>
    public class ManageUserViewModel : SignedInViewModel
    {
        #region Public Properties

        /// <inheritdoc cref="UserManagementType"/>
        public UserManagementType ManagementType { get; private set; }

        /// <summary>
        /// The email of the user
        /// </summary>
        public EntryViewModel<string> Email { get; set; }

        /// <summary>
        /// First name of the user
        /// </summary>
        public EntryViewModel<string> FirstName { get; set; }

        /// <summary>
        /// List of user's types of privileges
        /// </summary>
        public EntryViewModel<string> UserRole { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        public EntryViewModel<string> LastName { get; set; }

        /// <summary>
        /// The secured password string of the user
        /// </summary>
        public EntryViewModel<IHavePassword> Password { get; set; }

        /// <summary>
        /// The secured password string of the user to confirm this
        /// </summary>
        public EntryViewModel<IHavePassword> ConfirmPassword { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Try to save changes after add new user or edit existed
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// Discard edited changes
        /// </summary>
        public ICommand CancelCommand { get; set; }

        #endregion

        #region Constructor

        public ManageUserViewModel()
        {
            // TODO: Replace to ctor parameter
            ManagementType = UserManagementType.Edit;

            PageCaption = new PageCaptionViewModel(GetCaptionByManagementType(ManagementType));

            Email = new EntryViewModel<string>(nameof(Email));
            FirstName = new EntryViewModel<string>("Имя");
            LastName = new EntryViewModel<string>("Фамилия");
            Password = new EntryViewModel<IHavePassword>("Пароль");
            UserRole = new EntryViewModel<string>("Роль");
            ConfirmPassword = new EntryViewModel<IHavePassword>("Повторите пароль");

            CancelCommand = new RelayCommand(x => Cancel());
            SaveCommand = new RelayCommand(async (password) => await SaveChangesAsync(password));
        }

        #endregion

        #region Command Helpers

        /// <summary>
        /// Go to previous page
        /// </summary>
        private void Cancel()
        {
            IoC.IoC.Get<ApplicationViewModel>().GoToPreviousPage();
        }

        /// <inheritdoc cref="SaveCommand"/>
        private async Task SaveChangesAsync(object password)
        {
            await Task.Delay(1);
            GoToPage(ApplicationPage.UsersListToManage);
        }

        #endregion

        #region Model helpers

        /// <summary>
        /// Get page caption by <see cref="UserManagementType"/>
        /// </summary>
        /// <param name="managementType"><inheritdoc cref="UserManagementType"/></param>
        /// <returns>Page caption</returns>
        private string GetCaptionByManagementType(UserManagementType managementType)
        {
            switch (managementType)
            {
                case UserManagementType.Add:
                    return "Добавление нового пользователя";
                case UserManagementType.Edit:
                    return "Редактирование пользователя";
                default:
                    throw new ArgumentOutOfRangeException(nameof(managementType), managementType, null);
            }
        }

        #endregion
    }
}
