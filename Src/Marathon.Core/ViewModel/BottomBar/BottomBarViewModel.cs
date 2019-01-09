using System;
using Marathon.API.Services;
using System.Threading.Tasks;
using Marathon.API.Models.Marathon;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Dialogs;

namespace Marathon.Core.ViewModel.BottomBar
{
    using Kernel = IoC.IoC;

    /// <summary>
    /// The view model for a bottom bar control
    /// </summary>
    public class BottomBarViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Shows current date
        /// </summary>
        public TimeSpan? TimeToBegin { get; set; }

        public DateTime? StartupDate { get; set; }

        #endregion

        #region Constructor

        public BottomBarViewModel()
        {
            Task.Run(GetStartupDate);
        }

        #endregion

        #region Helpers

        private async Task GetStartupDate()
        {
            var genderService = Kernel.Get<IMarathonService>();

            try
            {
                StartupDate startupDate = await genderService.GetStartupDate();
                StartupDate = startupDate.Value;

                CalculateRemainingTime();
            }
            catch (Exception)
            {
                await Kernel.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Ошибка",
                    Message = "Неудалось получить дату начала марафона!"
                });
            }
        }

        public void CalculateRemainingTime()
        {
            if (StartupDate != null)
                TimeToBegin = StartupDate - DateTime.Now;
        }

        #endregion
    }
}
