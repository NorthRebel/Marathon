using Marathon.Core.ViewModel.RunnersListToManage.RunnersList.Design;

namespace Marathon.Core.ViewModel.RunnersListToManage.Design
{
    /// <summary>
    /// The design-time data for a <see cref="RunnersListToManageViewModel"/>
    /// </summary>
    public class RunnersListToManageDesignModel : RunnersListToManageViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static RunnersListToManageDesignModel Instance => new RunnersListToManageDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RunnersListToManageDesignModel()
        {
            Statuses.Value = new[]
            {
                "Оплата подтверждена",
                "Оплата не подтверждена"
            };

            Distances.Value = new[]
            {
                "10 км малый марафон",
                "42 км полный марафон"
            };

            AttributesToSort.Value = new[]
            {
                "Имя",
                "Фамилия",
                "Email",
                "Статус",
            };

            Runners = new RunnersListDesignModel();
        }

        #endregion
    }
}
