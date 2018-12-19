using System;
using System.Threading.Tasks;
using Marathon.Desktop.Dialogs;
using Marathon.Core.IoC.Interfaces;
using Marathon.Core.ViewModel.Dialogs;
using Marathon.Core.ViewModel.Inventory.Dialogs;
using Microsoft.Win32;

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

        /// <summary>
        /// Displays a dialog message of report about inventory state
        /// </summary>
        public Task ShowInventoryReport(InventoryReportDialogViewModel viewModel)
        {
            return new InventoryReportDialog().ShowDialog(viewModel);
        }

        /// <summary>
        /// Displays a dialog window where user can select file to open them
        /// </summary>
        public string OpenFile(OpenFileDialogViewModel viewModel)
        {
            var openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = viewModel.Filter,
                DefaultExt = viewModel.DefaultExtension,
            };

            if (openFileDialog.ShowDialog() == true)
                return openFileDialog.FileName;

            return string.Empty;
        }
    }
}
