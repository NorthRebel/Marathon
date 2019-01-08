using System.Linq;

namespace Marathon.Core.ViewModel.RunnersListToManage.RunnersList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="RunnersListViewModel"/>
    /// </summary>
    public class RunnersListDesignModel : RunnersListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static RunnersListDesignModel Instance => new RunnersListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RunnersListDesignModel()
        {
            Items = new[]
            {
                new RunnersListItemDesignModel(),
                new RunnersListItemViewModel
                {
                    FirstName = "Kristin",
                    LastName = "Perkins",
                    Email = "kris_per@gmail.com",
                    Status = "Оплата не подтверждена"
                },
                new RunnersListItemViewModel
                {
                    FirstName = "Oliver",
                    LastName = "Reviera",
                    Email = "ol_rev@gmail.com",
                    Status = "Оплата подтверждена"
                },
                new RunnersListItemViewModel
                {
                    FirstName = "Chloe",
                    LastName = "Denkins",
                    Email = "chloe_denk@gmail.com",
                    Status = "Оплата подтверждена"
                },
                new RunnersListItemViewModel
                {
                    FirstName = "Brian",
                    LastName = "Michael",
                    Email = "br_mich@gmail.com",
                    Status = "Оплата не подтверждена"
                },
            };

            ItemsCount = Items.Count();
        }

        #endregion
    }
}
