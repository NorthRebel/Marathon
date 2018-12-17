using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Marathon.Core.Helpers;
using Marathon.Core.Models;
using Marathon.Core.Models.Runner;
using Marathon.Core.Models.User;
using Marathon.Core.Services.Runner;
using Marathon.Core.Services.User;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Dialogs;
using Marathon.Core.ViewModel.Input;
using Marathon.Core.ViewModel.Models;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel
{
    using Kernel = IoC.IoC;

    /// <summary>
    /// The view model for a SignUpRunner page
    /// </summary>
    public class SignUpRunnerViewModel : PageViewModel, IRunnerProfile
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
        public ItemsEntryViewModel<string> Gender { get; set; }

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
        public ItemsEntryViewModel<string> Country { get; set; }

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

        /// <summary>
        /// Change <see cref="Photo"/> of a runner profile
        /// </summary>
        public ICommand ChangePhotoCommand { get; set; }

        #endregion

        #region Constructor

        public SignUpRunnerViewModel()
        {
            PageCaption = new PageCaptionViewModel("Регистрация бегуна",
                "Пожалуйста заполните всю информацию, чтобы зарегистрироваться в качестве бегуна");

            #region Initialize entries

            Email = new EntryViewModel<string>(nameof(Email));
            Password = new EntryViewModel<IHavePassword>("Пароль");
            ConfirmPassword = new EntryViewModel<IHavePassword>("Повторите пароль");
            FirstName = new EntryViewModel<string>("Имя");
            LastName = new EntryViewModel<string>("Фамилия");
            Gender = new ItemsEntryViewModel<string>("Пол");
            Photo = new EntryViewModel<string>("Фото файл");
            BirthDay = new EntryViewModel<DateTime>("Дата рождения");
            Country = new ItemsEntryViewModel<string>("Страна");

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
            Kernel.Get<ApplicationViewModel>().GoToPreviousPage();
        }

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        private async Task SignUpAsync(object password)
        {
            try
            {
                UserInfo newUser = await SignUpUserAsync(
                    Email.Value,
                    (password as IHavePassword).SecurePassword.Unsecure(), 
                    FirstName.Value, 
                    LastName.Value);

                await SaveUserInfoAsync(newUser);


                uint runnerId = await SignUpRunnerAsync(
                    newUser.Id, 
                    'M', 
                    BirthDay.Value, 
                    Country.Value, 
                    null);

                if (runnerId == default(uint))
                    throw new Exception("Runner id shouldn't have zero value!");

                GoToPage(ApplicationPage.SignUpToMarathon);
            }
            catch (Exception)
            {
                await Kernel.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Ошибка",
                    Message = "Неудалось зарегистрировать бегуна!"
                });
            }

        }

        private Task<UserInfo> SignUpUserAsync(string email, string password, string firstName, string lastName)
        {
            var userService = Kernel.Get<IUserService>();

            return userService.SignUpAsync(new UserSignUpCredentials
            {
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                // TODO: Create linked enumeration!
                UserTypeId = 'R'
            });
        }

        private Task<uint> SignUpRunnerAsync(uint userId, char genderId, DateTime dateOfBirth, string countryId, byte[] photo)
        {
            var runnerService = Kernel.Get<IRunnerService>();

            return runnerService.SignUpAsync(new RunnerSignUpCredentials
            {
                UserId = userId,
                GenderId = genderId,
                DateOfBirth = dateOfBirth,
                CountryId = countryId,
                Photo = photo
            });
        }

        private Task SaveUserInfoAsync(UserInfo userInfo)
        {
            return Kernel.ClientDataStore.SaveUserInfoAsync(userInfo);
        }

        #endregion
    }
}
