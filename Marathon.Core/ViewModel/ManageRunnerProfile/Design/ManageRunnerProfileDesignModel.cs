namespace Marathon.Core.ViewModel.ManageRunnerProfile.Design
{
    /// <summary>
    /// The design-time data for a <see cref="ManageRunnerProfileViewModel"/>
    /// </summary>
    public class ManageRunnerProfileDesignModel : ManageRunnerProfileViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ManageRunnerProfileDesignModel Instance => new ManageRunnerProfileDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ManageRunnerProfileDesignModel()
        {
            SignUpStatuses.Value = new[]
            {
                "Зарегистрирован",
                "Вышел на старт"
            };
        }

        #endregion
    }
}
