using System;
using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.SponsorRunner
{
    /// <summary>
    /// The view model for a sponsor info part of SponsorRunner page
    /// </summary>
    public class SponsorInfoViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Sponsor name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of runners to select for sponsorship
        /// </summary>
        public IEnumerable<string> Runners { get; set; }

        /// <summary>
        /// Selected runner for sponsorship
        /// </summary>
        public string SelectedRunner { get; set; }

        /// <summary>
        /// First and last name of card holder
        /// </summary>
        public string CardHolder { get; set; }

        /// <summary>
        /// 16-x Number of bank card
        /// </summary>
        public long? CardNumber { get; set; }

        /// <summary>
        /// Validity date of bank card
        /// </summary>
        public DateTimeOffset? CardValidity { get; set; }

        /// <summary>
        /// CVC code of bank card
        /// </summary>
        public short? CardCVCCode { get; set; }

        #endregion

        #region Constructor

        public SponsorInfoViewModel()
        {

        }

        #endregion
    }
}
