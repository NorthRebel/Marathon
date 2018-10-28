using System.Collections.Generic;
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
        public Stack<ApplicationPage> PreviousPages { get; private set; }

        /// <summary>
        /// True if the main title bar should be shown
        /// </summary>
        public bool MainTitleBarVisible { get; private set; } = true;

        /// <summary>
        /// True if the bottom bar should be shown
        /// </summary>
        public bool BottomBarVisible { get; private set; } = true;

        #region Constructor

        public ApplicationViewModel()
        {
            PreviousPages = new Stack<ApplicationPage>();
        }

        #endregion

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">The page to go to</param>
        /// <param name="goBack">Flag that indicates method doesn't push previous page to stack</param>
        protected override void GoToPage(ApplicationPage page, bool goBack = false)
        {
            if (!PreviousPages.Contains(page) && !goBack)
                PreviousPages.Push(CurrentPage);

            // Set the current page
            CurrentPage = page;

            // On main page visible main title bar
            MainTitleBarVisible = CurrentPage == ApplicationPage.Main;

            // Hide bottom bar on ShowCertificate page
            BottomBarVisible = CurrentPage != ApplicationPage.ShowCertificate;
        }

        /// <summary>
        /// Navigates to previous page if exists
        /// </summary>
        public void GoToPreviousPage()
        {
            if (PreviousPages.Count != default(int))
            {
                if (IoC.IoC.TitleBar.LogoutButtonVisible)
                    IoC.IoC.TitleBar.LogoutButtonVisible = false;
                GoToPage(PreviousPages.Pop(), true);
            }
        }
    }
}