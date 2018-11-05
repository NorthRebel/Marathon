using System.Threading.Tasks;
using Marathon.Core.IoC.Interfaces;
using Marathon.Core.ViewModel.Dialogs;
using Marathon.Desktop.Dialogs;

namespace Marathon.Desktop.IoC
{
    /// <summary>
    /// The applications implementation of the <see cref="IUIManager"/>
    /// </summary>
    public class UIManager : IUIManager
    {
        /// <summary>
        /// Displays a single message box to the user
        /// </summary>
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            return new DialogMessageBox().ShowDialog(viewModel);
        }

        /// <summary>
        /// Displays a dialog message about selected charity  
        /// </summary>
        public Task ShowAboutCharityInformation(AboutCharityDialogViewModel viewModel)
        {
            return new AboutCharityDialog().ShowDialog(viewModel);
        }

        /// <summary>
        /// Displays a dialog message about coordinators contacts
        /// </summary>
        public Task ShowCoordinatorsContacts(CoordinatorsContactsDialogViewModel viewModel)
        {
            return new CoordinatorsContactsDialog().ShowDialog(viewModel);
        }

        /// <summary>
        /// Displays a dialog message about activity levels
        /// </summary>
        public Task ShowAboutActivityLevels(AboutActivityLevelsDialogViewModel viewModel)
        {
            return new AboutActivityLevelsDialog().ShowDialog(viewModel);
        }
    }
}
