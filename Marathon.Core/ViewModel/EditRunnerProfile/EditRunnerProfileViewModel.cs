using System;
using Marathon.Core.Models;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Models;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.EditRunnerProfile
{
    /// <summary>
    /// The view model for a edit runner profile page
    /// </summary>
    public class EditRunnerProfileViewModel : PageViewModel, IRunnerProfile
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
        /// Try to save edited changes of current runner profile
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// Discard edited changes
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Change <see cref="PhotoPath"/> of a runner profile
        /// </summary>
        public ICommand ChangePhotoCommand { get; set; }

        #endregion

        #region Constructor

        public EditRunnerProfileViewModel()
        {
            PageCaption = new PageCaptionViewModel("Редактирование профиля");

            CancelCommand = new RelayCommand(x => Cancel());
            SaveCommand = new RelayCommand(async (password) => await SaveProfileChangesAsync(password));
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

        /// <summary>
        /// Save edited attributes of a runner profile
        /// </summary>
        private async Task SaveProfileChangesAsync(object password)
        {
            await Task.Delay(1);
            GoToPage(ApplicationPage.RunnerMenu);
        }

        #endregion
    }
}
