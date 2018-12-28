using Marathon.Core.ViewModel.UsersListToManage.UsersList.Design;

namespace Marathon.Core.ViewModel.UsersListToManage.Design
{
    /// <summary>
    /// The design-time data for a <see cref="UsersListToManageViewModel"/>
    /// </summary>
    public class UsersListToManageDesignModel : UsersListToManageViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static UsersListToManageDesignModel Instance => new UsersListToManageDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UsersListToManageDesignModel()
        {
            UserTypes = new[]
            {
                "Администратор",
                "Координатор",
                "Бегун"
            };

            AttributesToSort = new[]
            {
                "Имя",
                "Фамилия",
                "Email",
                "Роль",
            };

            Users = new UsersListDesignModel();
        }

        #endregion
    }
}
