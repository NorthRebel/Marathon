using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Marathon.Core.Models;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Input;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel
{
    /// <summary>
    /// The view model for a SignUpRunner page
    /// </summary>
    public class SignUpRunnerViewModel : PageViewModel
    {
        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public EntryViewModel<string> Email { get; set; }

        /// <summary>
        /// The secured password string of the user
        /// </summary>
        public EntryViewModel<IHavePassword> Password { get; set; }

        /// <summary>
        /// The secured password string of the user to confirm this
        /// </summary>
        public EntryViewModel<IHavePassword> ConfirmPassword { get; set; }

        /// <summary>
        /// First name of the user
        /// </summary>
        public EntryViewModel<string> FirstName { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        public EntryViewModel<string> LastName { get; set; }

        /// <summary>
        /// Gender of the user
        /// </summary>
        public EntryViewModel<string> Gender { get; set; }

        /// <summary>
        /// Path to photo of the user
        /// </summary>
        public EntryViewModel<string> Photo { get; set; }

        /// <summary>
        /// The date of birth of the user
        /// </summary>
        public EntryViewModel<DateTime> BirthDay { get; set; }

        /// <summary>
        /// Country name of the user
        /// </summary>
        public EntryViewModel<string> Country { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Try to sign up user
        /// </summary>
        public ICommand SignUpCommand { get; set; }

        /// <summary>
        /// Cancel sign in of user
        /// </summary>
        public ICommand CancelCommand { get; set; }

        #endregion

        #region Constructor

        public SignUpRunnerViewModel()
        {
            PageCaption = new PageCaptionViewModel
            {
                Caption = "Регистрация бегуна",
                Description = "Пожалуйста заполните всю информацию, чтобы зарегистрироваться в качестве бегуна"
            };

            #region Initialize entries

            Email = new EntryViewModel<string>(nameof(Email));
            Password = new EntryViewModel<IHavePassword>("Пароль");
            ConfirmPassword = new EntryViewModel<IHavePassword>("Повторите пароль");
            FirstName = new EntryViewModel<string>("Имя");
            LastName = new EntryViewModel<string>("Фамилия");
            Gender = new EntryViewModel<string>("Пол");
            Photo = new EntryViewModel<string>("Фото файл");
            BirthDay = new EntryViewModel<DateTime>("Дата рождения");
            Country = new EntryViewModel<string>("Страна");

            #endregion

            SignUpCommand = new RelayCommand(async (password) => await SignUpAsync(password));
            CancelCommand = new RelayCommand(x => Cancel());
        }

        #endregion

        #region Commands Helpers

        /// <summary>
        /// Go to previous page
        /// </summary>
        private void Cancel()
        {
            IoC.IoC.Get<ApplicationViewModel>().GoToPreviousPage();
        }

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        private async Task SignUpAsync(object password)
        {
            await Task.Delay(1);
            GoToPage(ApplicationPage.SignUpToMarathon);
        }

        #endregion
    }
}
