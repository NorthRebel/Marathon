namespace Marathon.Core.ViewModel.UsersListToManage.UsersList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="UsersListViewModel"/>
    /// </summary>
    public class UsersListDesignModel : UsersListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static UsersListDesignModel Instance => new UsersListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UsersListDesignModel()
        {
            Items = new[]
            {
                new UsersListItemDesignModel(),
                new UsersListItemDesignModel(),
                new UsersListItemDesignModel(),
                new UsersListItemDesignModel(),
                new UsersListItemDesignModel(),
                new UsersListItemDesignModel(),
                new UsersListItemDesignModel(),
                new UsersListItemDesignModel(),
                new UsersListItemDesignModel(),
                new UsersListItemDesignModel(),
                new UsersListItemDesignModel(),
            };
        }

        #endregion
    }
}
