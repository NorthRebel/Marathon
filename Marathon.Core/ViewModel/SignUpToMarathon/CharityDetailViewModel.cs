using System.Windows.Input;
using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Dialogs;
using Marathon.Core.ViewModel.Dialogs.Design;

namespace Marathon.Core.ViewModel.SignUpToMarathon
{
    public class CharityDetailViewModel
    {
        #region Properties

        /// <summary>
        /// List of charities to sponsorship
        /// </summary>
        public IEnumerable<string> Charities { get; set; }

        /// <summary>
        /// Selected charity
        /// </summary>
        public string Charity { get; set; }

        #endregion

        #region Commands

        public ICommand AboutSelectedCharityCommand { get; set; }

        #endregion

        public CharityDetailViewModel()
        {
            AboutSelectedCharityCommand = new RelayCommand(ShowCharityInfo);
        }

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
