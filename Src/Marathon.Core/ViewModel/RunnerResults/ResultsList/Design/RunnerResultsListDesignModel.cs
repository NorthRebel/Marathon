using System;

namespace Marathon.Core.ViewModel.RunnerResults.ResultsList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="RunnerResultsListViewModel"/>
    /// </summary>
    public class RunnerResultsListDesignModel : RunnerResultsListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static RunnerResultsListDesignModel Instance => new RunnerResultsListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RunnerResultsListDesignModel()
        {
            Items = new[]
            {
                new RunnerResultsListItemDesignModel(),
                new RunnerResultsListItemViewModel
                {
                    MarathonName = "2013 - Germany",
                    DistanceName = "10km Small Marathon",
                    CompletionTime = new TimeSpan(4,15,25),
                    CommonPosition = 604,
                    AgeCategory = "15-17",
                    PositionInCategory = 199
                },
                new RunnerResultsListItemViewModel
                {
                    MarathonName = "2012 - Vietnam",
                    DistanceName = "25km Medium Marathon",
                    CompletionTime = new TimeSpan(5,5,41),
                    CommonPosition = 623,
                    AgeCategory = "15-17",
                    PositionInCategory = 214
                },
                new RunnerResultsListItemViewModel
                {
                    MarathonName = "2011 - United Kingdom",
                    DistanceName = "42km Full Marathon",
                    CompletionTime = new TimeSpan(3,49,16),
                    CommonPosition = 752,
                    AgeCategory = "10-14",
                    PositionInCategory = 254
                }
            };
        }

        #endregion
    }
}
