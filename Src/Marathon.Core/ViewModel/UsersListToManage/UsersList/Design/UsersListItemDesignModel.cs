namespace Marathon.Core.ViewModel.UsersListToManage.UsersList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="UsersListItemViewModel"/>
    /// </summary>
    public class UsersListItemDesignModel : UsersListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static UsersListItemDesignModel Instance => new UsersListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UsersListItemDesignModel()
        {
            FirstName = "Eric";
            LastName = "Fluent";
            Email = "eric_flient@hotmail.com";
            UserType = "Runner";
        }

        #endregion
    }
}
