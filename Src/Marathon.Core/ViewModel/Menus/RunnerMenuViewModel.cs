using System.Windows.Input;
using Marathon.Core.Models;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Dialogs.Design;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.Menus
{
    /// <summary>
    /// The view model for a runner page
    /// </summary>
    public class RunnerMenuViewModel : SignedInViewModel
    {
        #region Commands
        
        /// <summary>
        /// Go to sign up marathon page
        /// </summary>
        public ICommand SignUpToMarathonCommand { get; set; }

        /// <summary>
        /// Show previous results of competitions
        /// </summary>
        public ICommand PreviousResultsCommand { get; set; }

        /// <summary>
        /// Go to edit runner profile page
        /// </summary>
        public ICommand EditProfileCommand { get; set; }

        /// <summary>
        /// Go to my sponsorship page
        /// </summary>
        public ICommand MySponsorshipCommand { get; set; }

        /// <summary>
        /// Show dialog about coordinators contacts
        /// </summary>
        public ICommand ShowContactsCommand { get; set; }

        #endregion

        #region Constructor

        public RunnerMenuViewModel()
        {
            SignUpToMarathonCommand = new RelayCommand(x => GoToPage(ApplicationPage.SignUpToMarathon));
            PreviousResultsCommand = new RelayCommand(ShowPreviousCompetitonsResults);
            EditProfileCommand = new RelayCommand(x => GoToPage(ApplicationPage.EditRunnerProfile));
            MySponsorshipCommand = new RelayCommand(ShowMySponsorshipOfCurenntMarathon);
            ShowContactsCommand = new RelayCommand(ShowCoordinatorsContacts);

            PageCaption = new PageCaptionViewModel("Меню бегуна");
        }

        #endregion

        #region Command Helpers

        private async void ShowCoordinatorsContacts(object obj)
        {
            // TODO: Remove dummy data
            await IoC.IoC.UI.ShowCoordinatorsContacts(new CoordinatorsContactsDialogDesignModel());
        }

        private void ShowMySponsorshipOfCurenntMarathon(object obj)
        {
            GoToPage(ApplicationPage.RunnerSponsorship);
        }
        
        private void ShowPreviousCompetitonsResults(object obj)
        {
            GoToPage(ApplicationPage.RunnerResults);
        }
        
        #endregion
    }
}
