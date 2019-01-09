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
        #region Private Members



        #endregion

        #region Public Properties

        /// <summary>
        /// Shows current date
        /// </summary>
        public TimeSpan? TimeToBegin { get; set; }

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

                TimeToBegin = startupDate.Value - DateTime.Now;
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

        #endregion
    }
}
