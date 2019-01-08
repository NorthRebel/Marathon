using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.CharitiesListToManage.CharitiesList
{
    /// <summary>
    /// The view model for charities list item
    /// </summary>
    public class CharitiesListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Name of charity
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Logo of charity
        /// </summary>
        public byte[] Logo { get; set; }

        /// <summary>
        /// Description of charity
        /// </summary>
        public string Description { get; set; }
    }
}
