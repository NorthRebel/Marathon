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
            Marathons.Items = new[]
            {
                "2014 - Japan",
                "2015 - Berlin",
            };
            Marathons.Value = Marathons.Items.First();

            Distances.Items = new[]
            {
                "10 км малый марафон",
                "42 км полный марафон"
            };
            Distances.Value = Distances.Items.First();

            Genders.Items = new[]
            {
                "Любой",
                "Мужской",
                "Женский"
            };
            Genders.Value = Genders.Items.First(); 

            AgeCategories.Items = new[]
            {
                "18 - 29",
                "30 - 35",
                "36 - 45"
            };
            AgeCategories.Value = AgeCategories.Items.First(); 

            TotalRunnersCount.Value = 1234;
            FinishedRunnersCount.Value = 1198;
            AverageTime.Value = new TimeSpan(4, 2, 10);

            ResultsCondition = new MarathonResultsCondition
            {
                Marathon = Marathons.Value,
                Distance = Distances.Value, 
                Gender = Genders.Value,
                AgeCategory = AgeCategories.Value
            };

            Results = new MarathonResultsListDesignModel();
        }

        #endregion
    }
}
