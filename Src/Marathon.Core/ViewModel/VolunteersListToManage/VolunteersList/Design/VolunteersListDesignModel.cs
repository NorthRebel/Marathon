using System.Linq;

namespace Marathon.Core.ViewModel.VolunteersListToManage.VolunteersList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="VolunteersListViewModel"/>
    /// </summary>
    public class VolunteersListDesignModel : VolunteersListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static VolunteersListDesignModel Instance => new VolunteersListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public VolunteersListDesignModel()
        {
            Items = new[]
            {
                new VolunteersListItemDesignModel(),
                new VolunteersListItemDesignModel(),
                new VolunteersListItemDesignModel(),
                new VolunteersListItemDesignModel(),
                new VolunteersListItemDesignModel(),
                new VolunteersListItemDesignModel(),
                new VolunteersListItemDesignModel(),
                new VolunteersListItemDesignModel(),
            };

            ItemsCount = Items.Count();
        }

        #endregion
    }
}
