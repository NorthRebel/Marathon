using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.MarathonOptions
{
    /// <summary>
    /// The view model for a marathon option item 
    /// </summary>
    public class MarathonOptionsItemViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Flag which indicates that item is selected
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// Description of this item
        /// </summary>
        public string Description { get; set; }

        #endregion
    }
}
