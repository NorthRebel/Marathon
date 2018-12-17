using Marathon.Core.IoC.Interfaces;
using Marathon.Core.Services.RequestProvider;
using Marathon.Core.Services.Runner;
using Marathon.Core.Services.User;
using Marathon.Core.ViewModel;
using Marathon.Core.ViewModel.TitleBar;
using Ninject;

namespace Marathon.Core.IoC
{
    /// <summary>
    /// The IoC container for application
    /// </summary>
    public static class IoC
    {
        #region Public Properties
        
        /// <summary>
        /// The kernel for IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// A shortcut to access the <see cref="IUIManager"/>
        /// </summary>
        public static IUIManager UI => IoC.Get<IUIManager>();

        /// <summary>
        /// A shortcut to access the <see cref="IClientDataStore"/>
        /// </summary>
        public static IClientDataStore ClientDataStore => IoC.Get<IClientDataStore>();

        /// <summary>
        /// A shortcut to access the <see cref="TitleBarViewModel"/>
        /// </summary>
        public static TitleBarViewModel TitleBar => IoC.Get<TitleBarViewModel>();

        /// <summary>
        /// A shortcut to access the <see cref="ApplicationViewModel"/>
        /// </summary>
        public static ApplicationViewModel Application => IoC.Get<ApplicationViewModel>();

        #endregion

        #region Construction

        /// <summary>
        /// Sets up the IoC container, binds all information required and is ready for use
        /// NOTE: Must be called as soon as your application starts up to ensure all 
        ///       services can be found
        /// </summary>
        public static void Setup()
        {
            // Bind all required view models
            BindViewModels();

            BindServices();
        }

        /// <summary>
        /// Binds all singleton view models
        /// </summary>
        private static void BindViewModels()
        {
            // Bind to a single instance of Application view model
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());

            // Bind to a single instance of Title Bar view model
            Kernel.Bind<TitleBarViewModel>().ToConstant(new TitleBarViewModel());
        }

        private static void BindServices()
        {
            Kernel.Bind<IRequestProvider>().To<RequestProvider>();

            Kernel.Bind<IUserService>().To<UserService>();
            Kernel.Bind<IRunnerService>().To<RunnerService>();

        }

        #endregion

        /// <summary>
        /// Get's a service from the IoC, of the specified type
        /// </summary>
        /// <typeparam name="T">The type to get</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}