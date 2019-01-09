using System;

namespace Marathon.Core.ViewModel.RunnerResults.ResultsList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="RunnerResultsListItemViewModel"/>
    /// </summary>
    public class RunnerResultsListItemDesignModel : RunnerResultsListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static RunnerResultsListItemDesignModel Instance => new RunnerResultsListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RunnerResultsListItemDesignModel()
        {
            MarathonName = "2014 - Japan";
            DistanceName = "42km Full Marathon";
            CompletionTime = new TimeSpan(4, 4, 12);
            CommonPosition = 598;
            AgeCategory = "18-29";
            PositionInCategory = 184;
        }

        #endregion
    }
}
