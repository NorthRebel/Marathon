using System;
using Validar;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.SignUpToMarathon
{

    /// <summary>
    /// The view model for a sponsorship details part of SignUpToMarathon page
    /// </summary>
    [InjectValidation]
    public class SponsorshipDetailsViewModel : BaseViewModel
    {
        /// <summary>
        /// Check validation for current and child models
        /// </summary>
        public override bool IsModelValid => base.IsModelValid && CharityDetail.IsModelValid;

        #region Private members

        private decimal? _sponsorshipAmount;

        #endregion

        #region Public Properties

        /// <summary>
        /// Notifies parent view model that <see cref="SponsorshipAmount"/> value has changed
        /// </summary>
        public event EventHandler<decimal> SponsorshipAmountUpdated;

        /// <summary>
        /// List of charity for sponsorship
        /// </summary>
        public CharityDetailViewModel CharityDetail { get; set; }

        /// <summary>
        /// Sponsorship amount for charity organization
        /// </summary>
        public decimal? SponsorshipAmount
        {
            get => _sponsorshipAmount;
            set
            {
                _sponsorshipAmount = value;
                OnPropertyChanged();
                SponsorshipAmountUpdated?.Invoke(this, _sponsorshipAmount ?? 0);
            }
        }

        #endregion

        #region Constructor

        public SponsorshipDetailsViewModel()
        {
            CharityDetail = new CharityDetailViewModel();
        }

        #endregion
    }
}
