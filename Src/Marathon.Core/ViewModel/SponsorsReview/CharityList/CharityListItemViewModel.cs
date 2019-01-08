using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.SponsorsReview.CharityList
{
    /// <summary>
    /// The view model for sponsors list item which get amount form sponsors
    /// </summary>
    public class CharityListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Logo of charity
        /// </summary>
        public byte[] Logo { get; set; }

        /// <summary>
        /// Name of charity
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sum of received amount from sponsors
        /// </summary>
        public decimal Summary { get; set; }
    }
}
