using PropertyChanged;
using Marathon.Core.Models;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Marathon.Core.ViewModel.Dialogs;

namespace Marathon.Core.ViewModel.Base
{
    using Kernel = IoC.IoC;

    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IDataErrorInfo _validationTemplate;

        /// <summary>
        /// Flag that indicates is model doesn't have validation errors
        /// </summary>
        public virtual bool IsModelValid => !((ValidationTemplate) _validationTemplate).HasErrors;

        protected BaseViewModel()
        {
            _validationTemplate = new ValidationTemplate(this);
        }

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

        #region ModelErrorsHandler

        protected Task NotifyAboutValidationErrors()
        {
            return Kernel.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Ошибка",
                Message = "Некоторые поля введены неверно!"
            });
        }

        #endregion
    }
}
