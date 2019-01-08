namespace Marathon.Core.ViewModel.Dialogs
{
    public class ConfirmMessageBoxDialogViewModel : BaseDialogViewModel
    {
        /// <summary>
        /// The message to display
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The text to use for the confirm action button
        /// </summary>
        public string YesText { get; set; }

        /// <summary>
        /// The text to use for the decline action button
        /// </summary>
        public string NoText { get; set; }
    }
}
