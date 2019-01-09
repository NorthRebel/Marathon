using System.Windows.Input;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Dialogs;
using Marathon.Core.ViewModel.Dialogs.Design;

namespace Marathon.Core.ViewModel.SponsorRunner
{
    /// <summary>
    /// The view model for a selected runner charity of SponsorRunner page
    /// </summary>
    public class RunnerCharityViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Name of runner charity organization
        /// </summary>
        public string CharityName { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Show dialog message about runner's charity
        /// </summary>
        public ICommand AboutSelectedCharityCommand { get; set; }

        #endregion

        #region Constructor

        public RunnerCharityViewModel()
        {
            AboutSelectedCharityCommand = new RelayCommand(ShowCharityInfo);
        }

        #endregion

        #region Command Helpers

        private async void ShowCharityInfo(object obj)
        {
            // TODO: Remove dummy implementation
            if (!(obj is string selectedCharity))
            {
                await IoC.IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Error",
                    Message = "Select  charity item to show info about it",
                    OkText = "OK"
                });

                return;
            }


            await IoC.IoC.UI.ShowAboutCharityInformation(new AboutCharityDialogDesignModel());
        }

        #endregion
    }
}
