namespace Marathon.Core.ViewModel.RunnerInfoManage.SignUpStatus.Design
{
    /// <summary>
    /// The design-time data for a <see cref="SignUpStatusListItemViewModel"/>
    /// </summary>
    public class SignUpStatusListItemDesignModel : SignUpStatusListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SignUpStatusListItemDesignModel Instance => new SignUpStatusListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SignUpStatusListItemDesignModel()
        {
            StatusName = "Зарегистрирован";
            Value = true;
        }

        #endregion
    }
}
