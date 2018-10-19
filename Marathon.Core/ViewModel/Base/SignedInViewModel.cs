namespace Marathon.Core.ViewModel.Base
{
    /// <summary>
    /// View model for a pages, which user is signed up
    /// </summary>
    public abstract class SignedInViewModel : BaseViewModel
    {
        /// <summary>
        /// Enables logout button on title bar
        /// </summary>
        protected SignedInViewModel()
        {
            IoC.IoC.TitleBar.LogoutButtonVisible = true;
        }
    }
}
