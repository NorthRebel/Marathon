using System.Windows.Input;
using Marathon.Core.Models;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.Menus
{
    /// <summary>
    /// The view model for a marathon menu
    /// </summary>
    public class MarathonMenuViewModel : PageViewModel
    {
        #region Commands

        /// <summary>
        /// Go to <see cref="ApplicationPage.AboutMarathon"/> page
        /// </summary>
        public ICommand AboutMarathonCommand { get; set; }

        /// <summary>
        /// Go to <see cref="ApplicationPage.HowLongMarathon"/> page
        /// </summary>
        public ICommand HowLongMarathonCommand { get; set; }

        /// <summary>
        /// Go to <see cref="ApplicationPage.MarathonResults"/> page
        /// </summary>
        public ICommand MarathonResultsCommand { get; set; }

        /// <summary>
        /// Go to <see cref="ApplicationPage.CharityList"/> page
        /// </summary>
        public ICommand CharityListCommand { get; set; }

        /// <summary>
        /// Go to <see cref="ApplicationPage.BMICalculator"/> page
        /// </summary>
        public ICommand BmiCalculatorCommand { get; set; }

        /// <summary>
        /// Go to <see cref="ApplicationPage.BMRCalculator"/> page
        /// </summary>
        public ICommand BmrCalculatorCommand { get; set; }

        #endregion

        #region Constructor

        public MarathonMenuViewModel()
        {
            // TODO: Implement checks in command helpers, if needs
            AboutMarathonCommand = new RelayCommand(x => GoToPage(ApplicationPage.AboutMarathon));
            HowLongMarathonCommand = new RelayCommand(x => GoToPage(ApplicationPage.HowLongMarathon));
            MarathonResultsCommand = new RelayCommand(x => GoToPage(ApplicationPage.MarathonResults));
            CharityListCommand = new RelayCommand(x => GoToPage(ApplicationPage.CharityList));
            BmiCalculatorCommand = new RelayCommand(x => GoToPage(ApplicationPage.BMICalculator));
            BmrCalculatorCommand = new RelayCommand(x => GoToPage(ApplicationPage.BMRCalculator));

            PageCaption = new PageCaptionViewModel
            {
                Caption = "Подробная информация"
            };
        }

        #endregion

        #region Command Helpers

        
        
        #endregion
    }
}
