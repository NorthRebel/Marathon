using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Dialogs;
using Marathon.Desktop.ViewModel;

namespace Marathon.Desktop.Dialogs
{
    /// <summary>
    /// The base class for any content that is being used inside of a <see cref="Desktop.DialogWindow"/>
    /// </summary>
    public class BaseDialogUserControl : UserControl
    {
        #region Protected Members

        /// <summary>
        /// The dialog window we will be contained within
        /// </summary>
        protected DialogWindow DialogWindow;

        #endregion

        #region Public Commands

        /// <summary>
        /// Closes this dialog
        /// </summary>
        public ICommand CloseCommand { get; private set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// The minimum width of this dialog
        /// </summary>
        public int WindowMinimumWidth { get; set; } = 250;

        /// <summary>
        /// The minimum height of this dialog
        /// </summary>
        public int WindowMinimumHeight { get; set; } = 100;

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 40;

        /// <summary>
        /// The title for this dialog
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseDialogUserControl()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                // Create a new dialog window
                DialogWindow = new DialogWindow();
                DialogWindow.ViewModel = new DialogWindowViewModel(DialogWindow);

                // Create close command
                CloseCommand = new RelayCommand(x => DialogWindow.Close());
            }
        }

        #endregion

        #region Public Dialog Show Methods

        /// <summary>
        /// Displays a single message box to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <typeparam name="T">The view model type for this control</typeparam>
        /// <returns></returns>
        public Task ShowDialog<T>(T viewModel) where T : BaseDialogViewModel
        {
            // Create a task to await the dialog closing
            var tcs = new TaskCompletionSource<bool>();

            // Run on UI thread
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    // Match controls expected sizes to the dialog windows view model
                    DialogWindow.ViewModel.WindowMinimumWidth = WindowMinimumWidth;
                    DialogWindow.ViewModel.WindowMinimumHeight = WindowMinimumHeight;
                    DialogWindow.ViewModel.TitleHeight = TitleHeight;
                    DialogWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;

                    // Set this control to the dialog window content
                    DialogWindow.ViewModel.Content = this;

                    // Setup this controls data context binding to the view model
                    DataContext = viewModel;

                    // Show in the center of the parent
                    DialogWindow.Owner = Application.Current.MainWindow;
                    DialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                    // Show dialog
                    DialogWindow.ShowDialog();
                }
                finally
                {
                    // Let caller know we finished
                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
        }

        #endregion
    }
}
