namespace Marathon.Core.ViewModel.Dialogs
{
    /// <summary>
    /// The view model for a about charity dialog
    /// </summary>
    public class AboutCharityDialogViewModel : BaseDialogViewModel
    {
        /// <summary>
        /// Name of charity
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Logo of charity
        /// </summary>
        public byte[] Logo { get; set; }

        /// <summary>
        /// Description of charity
        /// </summary>
        public string Description { get; set; }
    }
}
