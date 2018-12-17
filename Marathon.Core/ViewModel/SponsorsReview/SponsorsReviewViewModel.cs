using System.Windows.Input;
using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Input;
using Marathon.Core.ViewModel.PageCaption;
using Marathon.Core.ViewModel.SponsorsReview.CharityList;

namespace Marathon.Core.ViewModel.SponsorsReview
{
    /// <summary>
    /// The view model for a sponsors review page
    /// </summary>
    public class SponsorsReviewViewModel : PageViewModel
    {
        #region Public Properties

        /// <summary>
        /// Attributes of sponsorship organizations for <see cref="SortCommand"/>
        /// </summary>
        public ItemsEntryViewModel<string> AttributesToSort { get; set; }

        /// <inheritdoc cref="CharityListViewModel"/>
        public CharityListViewModel CharityList { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Sort sponsorship organization by selected attribute
        /// </summary>
        public ICommand SortCommand { get; set; }

        #endregion

        #region Constructor

        public SponsorsReviewViewModel()
        {
            PageCaption = new PageCaptionViewModel("Просмотр спонсоров");
        }

        #endregion

        #region Command Helpers



        #endregion
    }
}
