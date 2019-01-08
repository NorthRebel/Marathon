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
            Marathons = new[]
            {
                "2014 - Japan",
                "2015 - Berlin",
            };
            Marathon = Marathons.First();

            Distances = new[]
            {
                "10 км малый марафон",
                "42 км полный марафон"
            };
            Distance = Distances.First();

            Genders = new[]
            {
                "Любой",
                "Мужской",
                "Женский"
            };
            Gender = Genders.First(); 

            AgeCategories = new[]
            {
                "18 - 29",
                "30 - 35",
                "36 - 45"
            };
            AgeCategory = AgeCategories.First(); 

            TotalRunnersCount = 1234;
            FinishedRunnersCount = 1198;
            AverageTime = new TimeSpan(4, 2, 10);

            ResultsCondition = new MarathonResultsCondition
            {
                Marathon = Marathon,
                Distance = Distance, 
                Gender = Gender,
                AgeCategory = AgeCategory
            };

            Results = new MarathonResultsListDesignModel();
        }

        #endregion
    }
}
