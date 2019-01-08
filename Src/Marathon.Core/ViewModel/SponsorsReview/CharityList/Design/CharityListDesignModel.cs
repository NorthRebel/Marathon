using System.Linq;

namespace Marathon.Core.ViewModel.SponsorsReview.CharityList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="CharityListViewModel"/>
    /// </summary>
    public class CharityListDesignModel : CharityListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static CharityListDesignModel Instance => new CharityListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CharityListDesignModel()
        {
            Items = new[]
            {
                new CharityListItemDesignModel(), 
                new CharityListItemDesignModel(), 
                new CharityListItemDesignModel(), 
                new CharityListItemDesignModel(), 
                new CharityListItemDesignModel(), 
                new CharityListItemDesignModel(), 
                new CharityListItemDesignModel(), 
            };

            ItemsCount = Items.Count();
            TotalSummary = Items.Sum(x => x.Summary);
        }

        #endregion
    }
}
