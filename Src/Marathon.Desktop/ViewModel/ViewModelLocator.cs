using Marathon.Core.IoC;
using Marathon.Core.ViewModel;
using Kernel = Marathon.Core.IoC.IoC;

namespace Marathon.Desktop.ViewModel
{
    /// <summary>
    /// Locates view models from the IoC for use in binding in XAML files
    /// </summary>
    public class ViewModelLocator
    {
        #region Public Properties

        /// <summary>
        /// Singleton instance of the locator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        /// <summary>
        /// The application view model
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => Kernel.Get<ApplicationViewModel>();

        #endregion
    }
}
