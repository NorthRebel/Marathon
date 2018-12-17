using System.Collections.Generic;
using System.Windows.Input;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Dialogs;
using Marathon.Core.ViewModel.Dialogs.Design;
using Marathon.Core.ViewModel.Input;

namespace Marathon.Core.ViewModel.SignUpToMarathon
{
    public class CharityDetailViewModel : ItemsEntryViewModel<string>
    {
        #region Commands

        public ICommand AboutSelectedCharityCommand { get; set; }

        #endregion

        public CharityDetailViewModel(string label) : base(label)
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
