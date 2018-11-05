using Marathon.Core.ViewModel.Input;

namespace Marathon.Core.ViewModel.Dialogs.Design
{
    /// <summary>
    /// The design-time data for a <see cref="AboutActivityLevelsDialogViewModel"/>
    /// </summary>
    public class AboutActivityLevelsDialogDesignModel : AboutActivityLevelsDialogViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static AboutActivityLevelsDialogDesignModel Instance => new AboutActivityLevelsDialogDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AboutActivityLevelsDialogDesignModel()
        {
            ActivityLevels = new[]
            {
                new EntryViewModel<string>("Сидячий") {Value = "описание…"},
                new EntryViewModel<string>("Маленькая активность") {Value = "описание…"},
                new EntryViewModel<string>("Средняя активность") {Value = "описание…"},
            };
        }

        #endregion
    }
}
