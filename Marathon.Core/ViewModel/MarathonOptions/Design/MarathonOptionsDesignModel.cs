namespace Marathon.Core.ViewModel.MarathonOptions.Design
{
    /// <summary>
    /// The design-time data for a <see cref="MarathonOptionsViewModel"/>
    /// </summary>
    public class MarathonOptionsDesignModel : MarathonOptionsViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static MarathonOptionsDesignModel Instance => new MarathonOptionsDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MarathonOptionsDesignModel()
        {
            Items = new[]
            {
                new MarathonOptionsItemViewModel
                {
                    IsSelected = false,
                    Description = "Type A"
                },
                new MarathonOptionsItemViewModel
                {
                    IsSelected = true,
                    Description = "Type B"
                },
                new MarathonOptionsItemViewModel
                {
                    IsSelected = true,
                    Description = "Type C"
                }
            };
        }

        #endregion
    }
}
