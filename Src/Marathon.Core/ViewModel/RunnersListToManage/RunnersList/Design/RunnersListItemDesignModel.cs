namespace Marathon.Core.ViewModel.RunnersListToManage.RunnersList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="RunnersListItemViewModel"/>
    /// </summary>
    public class RunnersListItemDesignModel : RunnersListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static RunnersListItemDesignModel Instance => new RunnersListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RunnersListItemDesignModel()
        {
            FirstName = "Eric";
            LastName = "Fluent";
            Email = "eric_flient@hotmail.com";
            Status = "Оплата подтверждена";
        }

        #endregion
    }
}
