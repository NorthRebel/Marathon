namespace Marathon.Core.ViewModel.RunnerInfoManage.SignUpStatus.Design
{
    /// <summary>
    /// The design-time data for a <see cref="SignUpStatusListViewModel"/>
    /// </summary>
    public class SignUpStatusListDesignModel : SignUpStatusListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SignUpStatusListDesignModel Instance => new SignUpStatusListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SignUpStatusListDesignModel()
        {
            Items = new[]
            {
                new SignUpStatusListItemDesignModel(),
                new SignUpStatusListItemViewModel
                {
                    StatusName = "Вышел на старт",
                    Value = false
                }
            };
        }

        #endregion
    }
}
