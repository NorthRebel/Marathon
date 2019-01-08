namespace Marathon.Core.ViewModel.VolunteersListToManage.VolunteersList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="VolunteersListItemViewModel"/>
    /// </summary>
    public class VolunteersListItemDesignModel : VolunteersListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static VolunteersListItemDesignModel Instance => new VolunteersListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public VolunteersListItemDesignModel()
        {
            FirstName = "Arthur";
            LastName = "Bishop";
            CountryName = "Great Britain";
            Gender = "Male";
        }

        #endregion
    }
}
