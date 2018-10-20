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
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            return new DialogMessageBox().ShowDialog(viewModel);
        }

        /// <summary>
        /// Displays a dialog message about selected charity  
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public Task ShowAboutCharityInforamtion(AboutCharityDialogViewModel viewModel)
        {
            return new AboutCharityDialog().ShowDialog(viewModel);
        }
    }
}
