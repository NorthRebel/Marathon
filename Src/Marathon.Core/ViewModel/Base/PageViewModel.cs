using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.Base
{
    /// <summary>
    /// The viewModel for a pages with title content
    /// </summary>
    public abstract class PageViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Caption and description info about current page
        /// </summary>
        public PageCaptionViewModel PageCaption { get; set; }

        #endregion
    }
}
