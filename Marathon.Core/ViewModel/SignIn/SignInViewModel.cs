using System;
using Validar;
using System.Windows.Input;
using System.Threading.Tasks;
using Marathon.Core.Models.User;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Dialogs;
using Marathon.Core.Services.Interfaces;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.SignIn
{
    using Kernel = IoC.IoC;

    /// <summary>
    /// The view model for a UserSignIn page
    /// </summary>
    [InjectValidation]
    public class SignInViewModel : PageViewModel
    {
        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The password of the user
        /// </summary>
        public string Password { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Try to sign in user
        /// </summary>
        public ICommand SignInCommand { get; set; }

        /// <summary>
        /// Cancel sign in of user
        /// </summary>
        public ICommand CancelCommand { get; set; }

        #endregion

        #region Constructor

        public SignInViewModel()
        {
            PageCaption = new PageCaptionViewModel("Форма авторизации",
                "Пожалуйста, авторизуйтесь в системе, используя ваш адрес электронной почты и пароль");

            SignInCommand = new RelayCommand(async o => await SignInAsync());
            CancelCommand = new RelayCommand(x => Cancel());
        }

        #endregion

        #region Commands Helpers

        /// <summary>
        /// Go to previous page
        /// </summary>
        private void Cancel()
        {
            Kernel.Get<ApplicationViewModel>().GoToPreviousPage();
        }

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        private async Task SignInAsync()
        {
            if (!IsModelValid)
            {
                await NotifyAboutValidationErrors();
                return;
            }

            var userService = Kernel.Get<IUserService>();

            try
            {
                UserInfo result = await userService.SignInAsync(new UserSignInCredentials
                {
                    Email = Email,
                    Password = Password
                });

                if (result == null)
                    // TODO: Create custom exception if login fails
                    throw new Exception();

                await Kernel.Application.HandleSuccessfulLoginAsync(result);
            }
            catch (Exception)
            {
                await Kernel.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Ошибка",
                    Message = "Неудалось авторизовать пользователя!"
                });
            }
        }

        #endregion
    }
}
