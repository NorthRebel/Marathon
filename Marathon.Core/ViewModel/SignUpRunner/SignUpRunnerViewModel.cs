using System;
using Validar;
using System.IO;
using Marathon.Core.Models;
using System.Windows.Input;
using Marathon.Core.Helpers;
using System.Threading.Tasks;
using Marathon.Core.Models.User;
using System.Collections.Generic;
using Marathon.Core.Models.Runner;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Models;
using Marathon.Core.ViewModel.Dialogs;
using Marathon.Core.Services.Interfaces;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.SignUpRunner
{
    using Kernel = IoC.IoC;

    /// <summary>
    /// The view model for a SignUpRunner page
    /// </summary>
    [InjectValidation]
    public class SignUpRunnerViewModel : PageViewModel, IRunnerProfile
    {
        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// First name of the user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gender of the user
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// List of gender to select
        /// </summary>
        public IEnumerable<string> Genders { get; set; }

        /// <summary>
        /// Path to photo of the user
        /// </summary>
        public string PhotoPath { get; set; }

        /// <summary>
        /// Photo of the user
        /// </summary>
        public byte[] Photo { get; set; }

        /// <summary>
        /// The date of birth of the user
        /// </summary>
        public DateTime? BirthDay { get; set; }

        /// <summary>
        /// Country name of the user
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// List of countries to select
        /// </summary>
        public IEnumerable<string> Countries { get; set; }

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
        /// Change <see cref="PhotoPath"/> of a runner profile
        /// </summary>
        public ICommand ChangePhotoCommand { get; set; }

        #endregion

        #region Constructor

        public SignUpRunnerViewModel()
        {
            PageCaption = new PageCaptionViewModel("Регистрация бегуна",
                "Пожалуйста заполните всю информацию, чтобы зарегистрироваться в качестве бегуна");

            #region Initialize entries

            Task.Run(GetCountries);
            Task.Run(GetGenders);

            #endregion

            SignUpCommand = new RelayCommand(async (password) => await SignUpAsync(password));
            CancelCommand = new RelayCommand(x => Cancel());
            ChangePhotoCommand = new RelayCommand(x => OpenFileDialog());
        }

        #endregion

        #region Initialize entry lists

        private async Task GetCountries()
        {
            var countryService = Kernel.Get<ICountryService>();

            try
            {
                //Country.Items = await countryService.GetAllAsync();
            }
            catch (Exception)
            {
                var errorMessage = Kernel.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Ошибка",
                    Message = "Неудалось получить список стран!\nРегистрация невозможна"
                });

                if (errorMessage.Wait(TimeSpan.FromSeconds(10)))
                    Kernel.Application.GoToPreviousPage();
            }
        }

        private async Task GetGenders()
        {
            var genderService = Kernel.Get<IGenderService>();

            try
            {
               // Gender.Items = await genderService.GetAllAsync();
            }
            catch (Exception)
            {
                var errorMessage = Kernel.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Ошибка",
                    Message = "Неудалось получить список наименований гендеров!\nРегистрация невозможна"
                });

                if (errorMessage.Wait(TimeSpan.FromSeconds(10)))
                    Kernel.Application.GoToPreviousPage();
            }
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
        /// Show open file dialog for select photo of runner
        /// </summary>
        private void OpenFileDialog()
        {
            string photoPath = Kernel.UI.OpenFile(new OpenFileDialogViewModel
            {
                Title = "Выбор фото",
                DefaultExtension = "JPG",
                Filter = "Файлы изображений(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF"
            });

            if (!string.IsNullOrEmpty(photoPath))
            {
                PhotoPath = photoPath;
                Photo = File.ReadAllBytes(photoPath);
            }
        }

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        private async Task SignUpAsync(object password)
        {
            try
            {
                UserInfo newUser = await SignUpUserAsync((password as IHavePassword).SecurePassword.Unsecure());

                await SaveUserInfoAsync(newUser);

                int runnerId = await SignUpRunnerAsync(newUser.Id);

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

        private Task<UserInfo> SignUpUserAsync(string password)
        {
            var userService = Kernel.Get<IUserService>();

            return userService.SignUpAsync(new UserSignUpCredentials
            {
                Email = this.Email,
                Password = password,
                FirstName = this.FirstName,
                LastName = this.LastName,
                // TODO: Create linked enumeration!
                UserTypeId = 'R'
            });
        }

        private Task<int> SignUpRunnerAsync(int userId)
        {
            var runnerService = Kernel.Get<IRunnerService>();

            return runnerService.SignUpAsync(new RunnerSignUpCredentials
            {
                UserId = userId,
                Gender = this.Gender,
                DateOfBirth = (DateTime)BirthDay.Value,
                CountryName = this.Country,
                //Photo = 
            });
        }

        private Task SaveUserInfoAsync(UserInfo userInfo)
        {
            return Kernel.ClientDataStore.SaveUserInfoAsync(userInfo);
        }

        #endregion
    }
}
