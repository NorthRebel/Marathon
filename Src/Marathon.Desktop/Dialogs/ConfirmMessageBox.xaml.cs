using Marathon.Core.ViewModel.Dialogs;
using System.Threading.Tasks;
using System.Windows;

namespace Marathon.Desktop.Dialogs
{
    /// <summary>
    /// Interaction logic for ConfirmMessageBox.xaml
    /// </summary>
    public partial class ConfirmMessageBox : BaseDialogUserControl
    {
        #region Private members

        private bool _dialogResult;

        #endregion

        public ConfirmMessageBox()
        {
            InitializeComponent();
        }

        #region Public Dialog Show Methods

        /// <summary>
        /// Displays a single message box to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <typeparam name="T">The view model type for this control</typeparam>
        /// <returns></returns>
        public Task<bool> ShowDialogWithResult<T>(T viewModel) where T : BaseDialogViewModel
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
                    if (DialogWindow.ShowDialog() == true)
                    {
                        tcs.TrySetResult(_dialogResult);
                    }
                }
                catch
                {
                    tcs.TrySetResult(false);
                }
            });

            return tcs.Task;
        }

        #endregion

        #region Event handlers
        
        private void OnNoButtonClick(object sender, RoutedEventArgs e)
        {
            _dialogResult = false;
        }

        private void OnYesButtonClick(object sender, RoutedEventArgs e)
        {
            _dialogResult = true;
        }
        
        #endregion
    }
}
