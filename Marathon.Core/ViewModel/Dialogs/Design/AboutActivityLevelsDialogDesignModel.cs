using System.Collections.Generic;

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
                new KeyValuePair<string, string>("Сидячий","описание…"), 
                new KeyValuePair<string, string>("Маленькая активность","описание…"), 
                new KeyValuePair<string, string>("Средняя активность","описание…")
            };
        }

        #endregion
    }
}
