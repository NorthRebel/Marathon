using System;
using System.Linq;
using Marathon.Core.ViewModel.MarathonResults.Models;
using Marathon.Core.ViewModel.MarathonResults.ResultsList.Design;

namespace Marathon.Core.ViewModel.MarathonResults.Design
{
    /// <summary>
    /// The design-time data for a <see cref="MarathonResultsViewModel"/>
    /// </summary>
    public class MarathonResultsDesignModel : MarathonResultsViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static MarathonResultsDesignModel Instance => new MarathonResultsDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MarathonResultsDesignModel()
        {
            Marathons.Value = new[]
            {
                "2014 - Japan",
                "2015 - Berlin",
            };

            Distances.Value = new[]
            {
                "10 км малый марафон",
                "42 км полный марафон"
            };

            Genders.Value = new[]
            {
                "Любой",
                "Мужской",
                "Женский"
            };

            AgeCategories.Value = new[]
            {
                "18 - 29",
                "30 - 35",
                "36 - 45"
            };

            TotalRunnersCount.Value = 1234;
            FinishedRunnersCount.Value = 1198;
            AverageTime.Value = new TimeSpan(4, 2, 10);

            ResultsCondition = new MarathonResultsCondition
            {
                Marathon = Marathons.Value.First(),
                Distance = Distances.Value.First(), 
                Gender = Genders.Value.First(),
                AgeCategory = AgeCategories.Value.First()
            };

            Results = new MarathonResultsListDesignModel();
        }

        #endregion
    }
}
