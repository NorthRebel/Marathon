using System.Windows.Input;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Dialogs;
using Marathon.Core.ViewModel.Dialogs.Design;

namespace Marathon.Core.ViewModel.SignUpToMarathon
{
    public class CharityDetailViewModel
    {
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
