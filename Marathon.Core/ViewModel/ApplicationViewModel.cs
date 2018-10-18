
using Marathon.Core.Models;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel
{
    /// <summary>
    /// The application state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Main;

        /// <summary>
        /// True if the main title bar should be shown
        /// </summary>
        public bool MainTitleBarVisible { get; set; } = true;

        /// <summary>
        /// True if the bottom bar should be shown
        /// </summary>
        public bool BottomBarVisible { get; set; } = true;

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">The page to go to</param>
        protected override void GoToPage(ApplicationPage page)
        {
            // Set the current page
            CurrentPage = page;

            // On main page visible main title bar
            MainTitleBarVisible = CurrentPage == ApplicationPage.Main;
        }
    }
}