using System.Windows.Input;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Input;
using Marathon.Core.ViewModel.PageCaption;
using Marathon.Core.ViewModel.BMRCalculator.Models;
using Marathon.Core.ViewModel.Dialogs;

namespace Marathon.Core.ViewModel.BMRCalculator
{
    /// <summary>
    /// The view model for a BMR Calculator page
    /// </summary>
    public class BMRCalculatorViewModel : PageViewModel
    {
        #region Private Members

        /// <inheritdoc cref="Gender"/>
        private Gender? _selectedGender;

        #endregion

        #region Public Properties

        /// <summary>
        /// User's growth
        /// </summary>
        public EntryViewModel<double?> Growth { get; set; }

        /// <summary>
        /// User's weight
        /// </summary>
        public EntryViewModel<double?> Weight { get; set; }

        /// <summary>
        /// User's age
        /// </summary>
        public EntryViewModel<byte?> Age { get; set; }

        /// <inheritdoc cref="BMRResultViewModel"/>
        public BMRResultViewModel Result { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Calculate BMR by entered <see cref="Growth"/>, <see cref="Weight"/> and <see cref="Age"/>
        /// </summary>
        public ICommand CalculateCommand { get; set; }

        /// <summary>
        /// Close this page
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Select gender for get coefficients of BMR formula
        /// </summary>
        public ICommand SelectGenderCommand { get; set; }

        /// <summary>
        /// Shows a dialog about description of all activity levels
        /// </summary>
        public ICommand AboutActivityLevelsCommand { get; set; }

        #endregion

        #region Constructor

        public BMRCalculatorViewModel()
        {
            PageCaption = new PageCaptionViewModel
            {
                Caption = "BMR калькулятор"
            };

            Growth = new EntryViewModel<double?>("Рост");
            Weight = new EntryViewModel<double?>("Вес");
            Age = new EntryViewModel<byte?>("Возраст");

            Result = new BMRResultViewModel();

            CancelCommand = new RelayCommand(x => Cancel());
            CalculateCommand = new RelayCommand(CalculateBMR, CanCalculateBMR);
            SelectGenderCommand = new RelayCommand(SelectGender);
            AboutActivityLevelsCommand = new RelayCommand(ShowActivityLevels);
        }

        #endregion

        #region Command Helpers

        /// <inheritdoc cref="AboutActivityLevelsCommand"/>
        private async void ShowActivityLevels(object obj)
        {
            await IoC.IoC.UI.ShowAboutActivityLevels(new AboutActivityLevelsDialogViewModel
            {
                ActivityLevels = new []
                {
                    new EntryViewModel<string>("Сидячий образ") {Value = "Нет работы или работа за столом"}, 
                    new EntryViewModel<string>("Маленькая активность") {Value = "Мало физических работы или занятия спортом 1-3 раза в неделю"}, 
                    new EntryViewModel<string>("Средняя активность") {Value = "Умеренная физическая работа или занятия спортом 3 - 5 дней в неделю"}, 
                    new EntryViewModel<string>("Сильная активность") {Value = "Сильные физическая нагрузка или занятия спортом 6 - 7 дней в неделю"}, 
                    new EntryViewModel<string>("Максимальная активность") {Value = "Сильная ежедневная физическая нагрузка или спорт и физическая работа"}, 
                }
            });
        }
        
        /// <summary>
        /// Requirements to execute <see cref="CalculateCommand"/>
        /// </summary>
        private bool CanCalculateBMR(object obj)
        {
            return (_selectedGender != null) && (Growth != null && Growth.Value > 0) &&
                   (Weight != null && Weight.Value > 0) && (Age != null && Age.Value > 0);
        }

        /// <summary>
        /// Calculates basal metabolic rate by entered <see cref="Growth"/>, <see cref="Weight"/> and <see cref="Age"/>
        /// </summary>
        private void CalculateBMR(object obj)
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

        /// <inheritdoc cref="SelectGenderCommand"/>
        private void SelectGender(object obj)
        {
            if (!(obj is Gender selGender))
                return;

            _selectedGender = selGender;
        }

        #endregion
    }
}
