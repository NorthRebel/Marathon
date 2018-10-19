using System.ComponentModel;
using System.Runtime.CompilerServices;
using Marathon.Core.Models;
using PropertyChanged;

namespace Marathon.Core.ViewModel.Base
{
    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Command Helpers

        /// <summary>
        /// Move to another page
        /// </summary>
        protected virtual void GoToPage(ApplicationPage page, bool goBack = false)
        {
            IoC.IoC.Get<ApplicationViewModel>().GoToPage(page);
        }

        #endregion
    }
}
