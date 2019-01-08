using Marathon.Core.ViewModel.CharitiesListToManage.CharitiesList.Design;

namespace Marathon.Core.ViewModel.CharitiesListToManage.Design
{
    /// <summary>
    /// The design-time data for a <see cref="CharitiesListToManageViewModel"/>
    /// </summary>
    public class CharitiesListToManageDesignModel : CharitiesListToManageViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static CharitiesListToManageDesignModel Instance => new CharitiesListToManageDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CharitiesListToManageDesignModel()
        {
            Charities = new CharitiesListDesignModel();
        }

        #endregion
    }
}
