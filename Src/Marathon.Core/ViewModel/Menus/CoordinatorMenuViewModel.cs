using System.Windows.Input;
using Marathon.Core.Models;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.Menus
{
    /// <summary>
    /// The view model for a coordinator page
    /// </summary>
    public class CoordinatorMenuViewModel : SignedInViewModel
    {
        #region Commands

        /// <summary>
        /// Go to runners management page
        /// </summary>
        public ICommand ManageRunnersCommand { get; set; }

        /// <summary>
        /// Go to sponsors review page
        /// </summary>
        public ICommand SponsorsReviewCommand { get; set; }

        #endregion

        #region Constructor

        public CoordinatorMenuViewModel()
        {
            PageCaption = new PageCaptionViewModel("Меню координатора");

            ManageRunnersCommand = new RelayCommand(x => GoToPage(ApplicationPage.RunnersListToManage));
            SponsorsReviewCommand = new RelayCommand(x => GoToPage(ApplicationPage.SponsorsReview));
        }

        #endregion

        #region Command Helpers

        
        
        #endregion
    }
}
