namespace Marathon.Core.ViewModel.Dialogs
{
    /// <summary>
    /// The view model for a dialog window where user can select file to open them
    /// </summary>
    public class OpenFileDialogViewModel : BaseDialogViewModel
    {
        /// <summary>
        /// Gets or sets the filter string that determines what types of files are displayed
        /// </summary>
        /// <code>
        /// %Description%(%file type description (*.type)%;%file type description (*.type)%)|%file type (*.type)%;%file type (*.type)%
        /// </code>
        /// <example>
        /// Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF
        /// </example>
        public string Filter { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies the default extension string to use to filter the list of files that are displayed.
        /// </summary>
        public string DefaultExtension { get; set; }
    }
}
