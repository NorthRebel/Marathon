using Marathon.Core.ViewModel.RunnerResults.ResultsList.Design;

namespace Marathon.Core.ViewModel.RunnerResults.Design
{
    /// <summary>
    /// The design-time data for a <see cref="RunnerResultsViewModel"/>
    /// </summary>
    public class RunnerResultsDesignModel : RunnerResultsViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static RunnerResultsDesignModel Instance => new RunnerResultsDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RunnerResultsDesignModel()
        {
            Gender.Value = "Мужской";
            Results = new RunnerResultsListDesignModel();
        }

        #endregion
    }
}
