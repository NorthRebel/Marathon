
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
        /// The previous page of the application
        /// </summary>
        public ApplicationPage? PreviousPage { get; private set; }

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
            if (CurrentPage != page)
                PreviousPage = CurrentPage;

            // Set the current page
            CurrentPage = page;

            // On main page visible main title bar
            MainTitleBarVisible = CurrentPage == ApplicationPage.Main;
        }

        /// <summary>
        /// Navigates to previous page if exists
        /// </summary>
        public void GoToPreviousPage()
        {
            if (PreviousPage != null)
                GoToPage(PreviousPage.Value);
        }
    }
}