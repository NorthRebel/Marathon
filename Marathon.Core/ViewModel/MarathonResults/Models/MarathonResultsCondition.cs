namespace Marathon.Core.ViewModel.MarathonResults.Models
{
    /// <summary>
    /// Selected values of marathon properties to find results
    /// </summary>
    public class MarathonResultsCondition
    {
        /// <summary>
        /// Spent marathon
        /// </summary>
        public string Marathon { get; set; }

        /// <summary>
        /// Distance of marathon
        /// </summary>
        public string Distance { get; set; }

        /// <summary>
        /// Gender of runner
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Age category of runner
        /// </summary>
        public string AgeCategory { get; set; }
    }
}
