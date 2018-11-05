using System.Windows.Input;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Input;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.BMICalculator
{
    /// <summary>
    /// The view model for BMI calculator page
    /// </summary>
    public class BMICalculatorViewModel : PageViewModel
    {
        #region Public Properties

        /// <summary>
        /// User's growth
        /// </summary>
        public EntryViewModel<double?> Growth { get; set; }

        /// <summary>
        /// User's weight
        /// </summary>
        public EntryViewModel<double?> Weight { get; set; }

        /// <inheritdoc cref="BmiResultViewModel"/>
        public BMIResultViewModel Result { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Calculate BMI by entered <see cref="Growth"/> and <see cref="Weight"/>
        /// </summary>
        public ICommand CalculateCommand { get; set; }

        /// <summary>
        /// Close this page
        /// </summary>
        public ICommand CancelCommand { get; set; }

        #endregion

        #region Constructor

        public BMICalculatorViewModel()
        {
            PageCaption = new PageCaptionViewModel("BMI калькулятор");

            Growth = new EntryViewModel<double?>("Рост");
            Weight = new EntryViewModel<double?>("Вес");

            Result = new BMIResultViewModel();

            CancelCommand = new RelayCommand(x => Cancel());
            CalculateCommand = new RelayCommand(CalculateBMI);
        }

        #endregion

        #region Command Helpers

        /// <summary>
        /// Calculates body mass index by entered <see cref="Growth"/> and <see cref="Weight"/>
        /// </summary>
        private void CalculateBMI(object obj)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Go to previous page
        /// </summary>
        private void Cancel()
        {
            IoC.IoC.Get<ApplicationViewModel>().GoToPreviousPage();
        }

        #endregion
    }
}
