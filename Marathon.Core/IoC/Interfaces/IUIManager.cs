using System.Threading.Tasks;
using Marathon.Core.ViewModel.Dialogs;
using Marathon.Core.ViewModel.Inventory.Dialogs;

namespace Marathon.Core.IoC.Interfaces
{
    /// <summary>
    /// The UI manager that handles any UI interaction in the application
    /// </summary>
    public interface IUIManager
    {
        /// <summary>
        /// Displays a single message box to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        Task ShowMessage(MessageBoxDialogViewModel viewModel);

        /// <summary>
        /// Displays a dialog message about selected charity
        /// </summary>
        Task ShowAboutCharityInformation(AboutCharityDialogViewModel viewModel);

        /// <summary>
        /// Displays a dialog message about coordinators contacts
        /// </summary>
        Task ShowCoordinatorsContacts(CoordinatorsContactsDialogViewModel viewModel);

        /// <summary>
        /// Displays a dialog message about activity levels
        /// </summary>
        Task ShowAboutActivityLevels(AboutActivityLevelsDialogViewModel viewModel);

        /// <summary>
        /// Displays a dialog message of report about inventory state
        /// </summary>
        Task ShowInventoryReport(InventoryReportDialogViewModel viewModel);
    }
}
