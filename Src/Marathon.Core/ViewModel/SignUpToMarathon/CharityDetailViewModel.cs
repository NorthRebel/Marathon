using System;
using Validar;
using System.Windows.Input;
using Marathon.API.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Marathon.API.Models.Charity;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Dialogs;
using Marathon.Core.ViewModel.Dialogs.Design;

namespace Marathon.Core.ViewModel.SignUpToMarathon
{
    using Kernel = IoC.IoC;

    [InjectValidation]
    public class CharityDetailViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// List of charities to sponsorship
        /// </summary>
        public IEnumerable<Charity> Charities { get; set; }

        /// <summary>
        /// Selected charity
        /// </summary>
        public Charity Charity { get; set; }

        #endregion

        #region Commands

        public ICommand AboutSelectedCharityCommand { get; set; }

        #endregion

        public CharityDetailViewModel()
        {
            #region Initialize entries

            Task.Run(GetCharities);

            #endregion

            AboutSelectedCharityCommand = new RelayCommand(ShowCharityInfo);
        }

        #region Initialize entry lists

        private async Task GetCharities()
        {
            var charityService = Kernel.Get<ICharityService>();

            try
            {
                Charities = await charityService.GetAllAsync();
            }
            catch (Exception)
            {
                var errorMessage = Kernel.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Ошибка",
                    Message = "Неудалось получить список благотворительных организаций!\nРегистрация невозможна"
                });

                if (errorMessage.Wait(TimeSpan.FromSeconds(10)))
                    Kernel.Application.GoToPreviousPage();
            }
        }

        #endregion

        #region Command Helpers

        private async void ShowCharityInfo(object obj)
        {
            if (!(obj is Charity selectedCharity))
            {
                await Kernel.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Ошибка",
                    Message = "Выберите благотворительную организацию, для просмотра дополнительной информации",
                    OkText = "OK"
                });

                return;
            }

            try
            {
                AboutCharity aboutCharity = await GetInfoAboutCharity(selectedCharity.Id);

                await Kernel.UI.ShowAboutCharityInformation(new AboutCharityDialogDesignModel
                {
                    Name = aboutCharity.Name,
                    Description = aboutCharity.Description,
                    Logo = aboutCharity.Logo
                });
            }
            catch (Exception)
            {
                await Kernel.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Ошибка",
                    Message = "Произошла ошибка при получении данных!\nПросмотр дополнительной информации невозможен"
                });
            }
        }

        private Task<AboutCharity> GetInfoAboutCharity(int id)
        {
            var charityService = Kernel.Get<ICharityService>();

            return charityService.AboutCharity(id);
        }

        #endregion
    }
}
