using Marathon.Core.ViewModel.Input;
using Marathon.Core.ViewModel.SponsorsReview.CharityList.Design;

namespace Marathon.Core.ViewModel.SponsorsReview.Design
{
    /// <summary>
    /// The design-time data for a <see cref="SponsorsReviewViewModel"/>
    /// </summary>
    public class SponsorsReviewDesignModel : SponsorsReviewViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SponsorsReviewDesignModel Instance => new SponsorsReviewDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SponsorsReviewDesignModel()
        {
            AttributesToSort = new ItemsEntryViewModel<string>("Отсортировать")
            {
                Items = new []
                {
                    "Наименование",
                    "Сумма",
                }
            };

            CharityList = new CharityListDesignModel();
        }

        #endregion
    }
}
