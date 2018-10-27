using System;
using System.Collections.Generic;
using System.Windows.Input;
using Marathon.Core.Models;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Input;
using Marathon.Core.ViewModel.PageCaption;
using Marathon.Core.ViewModel.RunnerInfoManage.SignUpStatus;

namespace Marathon.Core.ViewModel.RunnerInfoManage
{
    /// <summary>
    /// The view model for a runner info manage page
    /// </summary>
    public class RunnerInfoManageViewModel : PageViewModel
    {
        #region Public Properties

        /// <summary>
        /// Runner's email
        /// </summary>
        public EntryViewModel<string> Email { get; set; }

        /// <summary>
        /// Runner's first name
        /// </summary>
        public EntryViewModel<string> FirstName { get; set; }

        /// <summary>
        /// Runner's last name
        /// </summary>
        public EntryViewModel<string> LastName { get; set; }

        /// <summary>
        /// Runner's gender
        /// </summary>
        public EntryViewModel<string> Gender { get; set; }

        /// <summary>
        /// Runner's date of birth
        /// </summary>
        public EntryViewModel<DateTime> DateOfBirth { get; set; }

        /// <summary>
        /// Runner's country name
        /// </summary>
        public EntryViewModel<string> CountryName { get; set; }

        /// <summary>
        /// Charity organization that runner selected when signing up 
        /// </summary>
        public EntryViewModel<string> CharityOrganization { get; set; }

        /// <summary>
        /// Total amount of sponsorship for current runner from sponsors 
        /// </summary>
        public EntryViewModel<decimal> SponsorshipAmount { get; set; }

        /// <summary>
        /// Race kit that runner selected when signed up to current marathon
        /// </summary>
        public EntryViewModel<string> SelectedRaceKit { get; set; }

        /// <summary>
        /// Marathon distance that runner selected when signed up to current marathon
        /// </summary>
        public EntryViewModel<string> SelectedDistance { get; set; }

        /// <summary>
        /// Runner's photo
        /// </summary>
        public byte[] Photo { get; set; }

        /// <summary>
        /// List of progress passing statuses for runner
        /// </summary>
        public SignUpStatusListViewModel Statuses { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Shows runner certificate preview
        /// </summary>
        public ICommand ShowCertificateCommand { get; set; }

        /// <summary>
        /// Print runner's marathon badge
        /// </summary>
        public ICommand PrintBadgeCommand { get; set; }

        /// <summary>
        /// Go to runner credentials edit page
        /// </summary>
        public ICommand ManageRunnerCommand { get; set; }

        #endregion

        #region Constructor

        public RunnerInfoManageViewModel()
        {
            PageCaption = new PageCaptionViewModel
            {
                Caption= "Управление бегуном"
            };

            Email = new EntryViewModel<string>(nameof(Email));
            FirstName = new EntryViewModel<string>("Имя");
            LastName = new EntryViewModel<string>("Фамилия");
            Gender = new EntryViewModel<string>("Пол");
            DateOfBirth = new EntryViewModel<DateTime>("Дата рождения");
            CountryName = new EntryViewModel<string>("Страна");
            CharityOrganization = new EntryViewModel<string>("Благотворит");
            SponsorshipAmount = new EntryViewModel<decimal>("Пожертвовано");
            SelectedRaceKit = new EntryViewModel<string>("Выбранный пакет");
            SelectedDistance = new EntryViewModel<string>("Дистанция");

            ShowCertificateCommand = new RelayCommand(x => GoToPage(ApplicationPage.ShowSertificate));
            PrintBadgeCommand = new RelayCommand(PrintBadge);
            ManageRunnerCommand = new RelayCommand(x => GoToPage(ApplicationPage.ManageRunnerProfile));
        }
        #endregion

        #region Command Helpers

        /// <summary>
        /// Print runner's marathon badge
        /// </summary>
        /// <param name="obj"></param>
        private void PrintBadge(object obj)
        {
            throw new NotImplementedException();
        }
        
        #endregion
    }
}
