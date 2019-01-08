using System.Linq;

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
                    Amount = 240
                },
                new SponsorshipListItemViewModel
                {
                    Name = "Dylan Smith",
                    Amount = 1250
                },
                new SponsorshipListItemViewModel
                {
                    Name = "Eric Plymouth",
                    Amount = 999
                },
                new SponsorshipListItemViewModel
                {
                    Name = "Elsa Vogue",
                    Amount = 815
                },
                new SponsorshipListItemViewModel
                {
                    Name = "Julie Robertson",
                    Amount = 1689
                },
                new SponsorshipListItemViewModel
                {
                    Name = "James Diamond",
                    Amount = 240
                },
            };

            TotalAmount = Items.Sum(x => x.Amount);
        }

        #endregion
    }
}
