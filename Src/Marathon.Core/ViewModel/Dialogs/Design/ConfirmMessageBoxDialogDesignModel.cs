namespace Marathon.Core.ViewModel.Dialogs.Design
{
    /// <summary>
    /// The design-time data for a <see cref="ConfirmMessageBoxDialogViewModel"/>
    /// </summary>
    public class ConfirmMessageBoxDialogDesignModel : ConfirmMessageBoxDialogViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ConfirmMessageBoxDialogDesignModel Instance => new ConfirmMessageBoxDialogDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ConfirmMessageBoxDialogDesignModel()
        {
            Message = "Дествие будет отменено! Продолжить?";
            YesText = "Да";
            NoText = "Нет";
        }

        #endregion
    }
}
