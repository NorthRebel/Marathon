namespace Marathon.Core.ViewModel.CharitiesListToManage.CharitiesList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="CharitiesListViewModel"/>
    /// </summary>
    public class CharitiesListDesignModel : CharitiesListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static CharitiesListDesignModel Instance => new CharitiesListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CharitiesListDesignModel()
        {
            Items = new[]
            {
                new CharitiesListItemDesignModel(), 
                new CharitiesListItemDesignModel(), 
                new CharitiesListItemDesignModel(), 
                new CharitiesListItemDesignModel(), 
                new CharitiesListItemDesignModel(), 
                new CharitiesListItemDesignModel(), 
                new CharitiesListItemDesignModel(), 
                new CharitiesListItemDesignModel(), 
            };
        }

        #endregion
    }
}
