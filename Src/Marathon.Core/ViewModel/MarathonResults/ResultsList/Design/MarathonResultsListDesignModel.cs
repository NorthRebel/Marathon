using System;

namespace Marathon.Core.ViewModel.MarathonResults.ResultsList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="MarathonResultsListViewModel"/>
    /// </summary>
    public class MarathonResultsListDesignModel : MarathonResultsListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static MarathonResultsListDesignModel Instance => new MarathonResultsListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MarathonResultsListDesignModel()
        {
            Items = new[]
            {
                new MarathonResultsListItemViewModel
                {
                    Position = 1,
                    CompletionTime = new TimeSpan(2, 26, 27),
                    RunnerName = "First Runner",
                    CountryName = "Russia",
                    MarathonName = "2014 - Japan"
                },
                new MarathonResultsListItemViewModel
                {
                    Position = 2,
                    CompletionTime = new TimeSpan(2, 29, 23),
                    RunnerName = "Second Runner",
                    CountryName = "Brazil",
                    MarathonName = "2015 - Berlin"
                },
                new MarathonResultsListItemViewModel
                {
                    Position = 3,
                    CompletionTime = new TimeSpan(2, 33, 10),
                    RunnerName = "Third Runner",
                    CountryName = "USA",
                    MarathonName = "2014 - Japan"
                },
                new MarathonResultsListItemViewModel
                {
                    Position = 4,
                    CompletionTime = new TimeSpan(2, 33, 29),
                    RunnerName = "Fourth Runner",
                    CountryName = "France",
                    MarathonName = "2015 - Berlin"
                },
                new MarathonResultsListItemViewModel
                {
                    Position = 5,
                    CompletionTime = new TimeSpan(2, 35, 49),
                    RunnerName = "Fifth Runner",
                    CountryName = "Italy",
                    MarathonName = "2015 - Berlin"
                }
            };
        }

        #endregion
    }
}
