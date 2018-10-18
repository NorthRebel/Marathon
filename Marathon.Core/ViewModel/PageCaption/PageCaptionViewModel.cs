using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.PageCaption
{
    /// <summary>
    /// The view model for a page caption control
    /// </summary>
    public class PageCaptionViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Caption of a page
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Description, which explains information about page content 
        /// </summary>
        public string Description { get; set; }

        #endregion

    }
}
