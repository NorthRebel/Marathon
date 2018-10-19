namespace Marathon.Core.ViewModel.MarathonOptions.Design
{
    /// <summary>
    /// The design-time data for a <see cref="MarathonOptionsItemViewModel"/>
    /// </summary>
    public class MarathonOptionsItemDesignModel : MarathonOptionsItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static MarathonOptionsItemDesignModel Instance => new MarathonOptionsItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MarathonOptionsItemDesignModel()
        {
            IsSelected = true;
            Description = "42km Полный марафон($145)";
        }

        #endregion
    }
}
