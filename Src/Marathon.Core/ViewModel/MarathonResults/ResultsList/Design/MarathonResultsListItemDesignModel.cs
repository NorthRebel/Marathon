using System;

namespace Marathon.Core.ViewModel.MarathonResults.ResultsList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="MarathonResultsListItemViewModel"/>
    /// </summary>
    public class MarathonResultsListItemDesignModel : MarathonResultsListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static MarathonResultsListItemDesignModel Instance => new MarathonResultsListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MarathonResultsListItemDesignModel()
        {
            Position = 1;
            CompletionTime = new TimeSpan(2, 26, 27);
            RunnerName = "First Runner";
            CountryName = "Russia";
            MarathonName = "2014 - Japan";
        }

        #endregion
    }
}
