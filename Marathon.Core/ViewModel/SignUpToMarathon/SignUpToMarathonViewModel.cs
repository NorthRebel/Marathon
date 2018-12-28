using System;
using Validar;
using Marathon.Core.Models;
using System.Windows.Input;
using System.Threading.Tasks;
using Marathon.Core.Models.User;
using System.Collections.Generic;
using Marathon.Core.Models.RaceKit;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.Models.Marathon;
using Marathon.Core.ViewModel.Dialogs;
using Marathon.Core.Services.Interfaces;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.SignUpToMarathon
{
    using Kernel = IoC.IoC;

    /// <summary>
    /// The view model for a SignUpToMarathon page
    /// </summary>
    [InjectValidation]
    public class SignUpToMarathonViewModel : SignedInViewModel
    {
        /// <summary>
        /// Check validation for current and child models
        /// </summary>
        public override bool IsModelValid => base.IsModelValid && SponsorshipDetails.IsModelValid;
        
        #region Private members

        private decimal _sponsorshipAmount;

        private RaceKit _selectedRaceKit;

        private EventType _selectedMarathonType;

        #endregion

        #region Public Properties

        /// <summary>
        /// Types of marathon for take part them
        /// </summary>
        public IEnumerable<EventType> MarathonTypesToSelect { get; set; }

        /// <summary>
        /// Collection of selected marathon types
        /// </summary>
        public EventType SelectedMarathonType
        {
            get => _selectedMarathonType;
            set
            {
                _selectedMarathonType = value;
                OnPropertyChanged();
                UpdatePaymentInfo();
            }
        }

        /// <summary>
        /// Types of race kit which runner can use it in marathon
        /// </summary>
        public IEnumerable<RaceKit> RaceKits { get; set; }

        /// <summary>
        /// Key of selected race kit
        /// </summary>
        public RaceKit SelectedRaceKit
        {
            get => _selectedRaceKit;
            set
            {
                _selectedRaceKit = value;
                OnPropertyChanged();
                UpdatePaymentInfo();
            }
        }

        /// <summary>
        /// Details which means payment amount for charity organization 
        /// </summary>
        public SponsorshipDetailsViewModel SponsorshipDetails { get; set; }

        /// <summary>
        /// Indicates sum of price of selected RaceKits and MarathonType
        /// </summary>
        public PaymentSignInMarathonViewModel PaymentDetail { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Cancellation of sign up
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Confirmation of sign up
        /// </summary>
        public ICommand SignInCommand { get; set; }

        #endregion

        #region Constructor

        public SignUpToMarathonViewModel()
        {
            SignInCommand = new RelayCommand(async o => await CancelSignUp());
            CancelCommand = new RelayCommand(async o => await ConfirmSignUp());


            #region Initialize entries

            Task.Run(GetMarathonTypes);
            Task.Run(GetRaceKits);

            #endregion

            SponsorshipDetails = new SponsorshipDetailsViewModel();
            PaymentDetail = new PaymentSignInMarathonViewModel();

            PageCaption = new PageCaptionViewModel("Регистрация на марафон",
                "Пожалуйста, заполните всю информацию, чтобы зарегистрироваться на Skills Marathon 2016 проводимом в Москве. Россия. " +
                "С вами свяжутся после регистрации, для уточнения оплаты и другой информации.");

            SponsorshipDetails.SponsorshipAmountUpdated += OnSponsorshipAmountUpdates;
        }


        #endregion

        #region Initialize entry lists

        private async Task GetMarathonTypes()
        {
            var marathonService = Kernel.Get<IMarathonService>();

            try
            {
                MarathonTypesToSelect = await marathonService.GetEventTypes();
            }
            catch (Exception)
            {
                var errorMessage = Kernel.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Ошибка",
                    Message = "Неудалось получить список видов марафона!\nРегистрация на марафон невозможна"
                });

                if (errorMessage.Wait(TimeSpan.FromSeconds(10)))
                    Kernel.Application.GoToPreviousPage();
            }
        }

        private async Task GetRaceKits()
        {
            var raceKitService = Kernel.Get<IRaceKitService>();

            try
            {
                RaceKits = await raceKitService.GetAll();
            }
            catch (Exception)
            {
                var errorMessage = Kernel.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Ошибка",
                    Message = "Неудалось получить список вариантов комплекта для марафона!\nРегистрация на марафон невозможна"
                });

                if (errorMessage.Wait(TimeSpan.FromSeconds(10)))
                    Kernel.Application.GoToPreviousPage();
            }
        }

        #endregion

        #region Command Helpers

        private Task CancelSignUp()
        {
            var confirmMessage = Kernel.UI.ShowConfirmMessage(new ConfirmMessageBoxDialogViewModel
            {
                Title = "Отмена регистрации",
                Message = "Регистрация на марафон будет отменена! Продолжить?",
                YesText = "Да",
                NoText = "Нет"
            });

            return confirmMessage.ContinueWith(task =>
            {
                if (task.Result)
                    GoToPage(ApplicationPage.RunnerMenu);
            });
        }

        private async Task ConfirmSignUp()
        {
            if (!IsModelValid)
            {
                await NotifyAboutValidationErrors();
                return;
            }

            try
            {
                MarathonSignUp marathonSignUp = await CreateSignUpModel();

                var marathonService = Kernel.Get<IMarathonService>();

                int signUpId = await marathonService.SignUp(marathonSignUp);

                if (signUpId == default(int))
                    throw new Exception("Marathon sign up id shouldn't have zero value!");

                GoToPage(ApplicationPage.SignUpRunnerConfirm);
            }
            catch (Exception)
            {
                await Kernel.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Ошибка",
                    Message = "Неудалось зарегистрироваться на марафон!"
                });
            }
        }

        private async Task<MarathonSignUp> CreateSignUpModel()
        {
            return new MarathonSignUp
            {
                RunnerId = await GetRunnerId(),
                CharityId = SponsorshipDetails.CharityDetail.Charity.Id,
                RaceKitOptionId = SelectedRaceKit.Id,
                EventTypeId = SelectedMarathonType.Id,
                Cost = PaymentDetail.Payment,
                SponsorshipTarget = SponsorshipDetails.SponsorshipAmount.Value
            };
        }

        private async Task<int> GetRunnerId()
        {
            UserInfo userInfo = await Kernel.ClientDataStore.GetUserInfoAsync();

            var runnerService = Kernel.Get<IRunnerService>();

            return await runnerService.GetId(userInfo.Id);
        }

        #endregion

        #region Event helpers

        private void OnSponsorshipAmountUpdates(object sender, decimal sponsorshipAmount)
        {
            _sponsorshipAmount = sponsorshipAmount;
            UpdatePaymentInfo();
        }

        #endregion

        #region Model helpers

        private void UpdatePaymentInfo()
        {
            PaymentDetail.Payment = _sponsorshipAmount + (SelectedRaceKit?.Cost ?? 0) + (SelectedMarathonType?.Cost ?? 0);
        }

        #endregion
    }
}
