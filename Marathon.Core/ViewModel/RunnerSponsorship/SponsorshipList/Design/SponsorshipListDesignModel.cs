namespace Marathon.Core.ViewModel.RunnerSponsorship.SponsorshipList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="SponsorshipListViewModel"/>
    /// </summary>
    public class SponsorshipListDesignModel : SponsorshipListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SponsorshipListDesignModel Instance => new SponsorshipListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SponsorshipListDesignModel()
        {
            Items = new[]
            {
                new SponsorshipListItemDesignModel(),
                new SponsorshipListItemViewModel
                {
                    Name = "Anna Owen",
                    Ammount = 240
                },
                new SponsorshipListItemViewModel
                {
                    Name = "Dylan Smith",
                    Ammount = 1250
                },
                new SponsorshipListItemViewModel
                {
                    Name = "Eric Plymouth",
                    Ammount = 999
                },
                new SponsorshipListItemViewModel
                {
                    Name = "Elsa Vogue",
                    Ammount = 815
                },
                new SponsorshipListItemViewModel
                {
                    Name = "Julie Robertson",
                    Ammount = 1689
                },
                new SponsorshipListItemViewModel
                {
                    Name = "James Diamond",
                    Ammount = 240
                },
            };
        }

        #endregion
    }
}
