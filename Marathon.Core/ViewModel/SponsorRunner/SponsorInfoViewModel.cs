using System;
using System.Collections.Generic;
using Marathon.Core.ViewModel.Input;
using Marathon.Core.ViewModel.MarathonOptions;

namespace Marathon.Core.ViewModel.SponsorRunner
{
    /// <summary>
    /// The view model for a sponsor info part of SponsorRunner page
    /// </summary>
    public class SponsorInfoViewModel : OptionsViewModel
    {
        #region Public Properties

        /// <summary>
        /// Sponsor name
        /// </summary>
        public EntryViewModel<string> Name { get; set; }

        /// <summary>
        /// List of runners to select for sponsorship
        /// </summary>
        public EntryViewModel<IEnumerable<string>> Runner { get; set; }

        /// <summary>
        /// Selected runner for sponsorship
        /// </summary>
        public string SelectedRunner { get; set; }

        /// <summary>
        /// First and last name of card holder
        /// </summary>
        public EntryViewModel<string> CardHolder { get; set; }

        /// <summary>
        /// 16-x Number of bank card
        /// </summary>
        public EntryViewModel<long> CardNumber { get; set; }

        /// <summary>
        /// Validity date of bank card
        /// </summary>
        public EntryViewModel<DateTimeOffset> CardValidity { get; set; }

        /// <summary>
        /// CVC code of bank card
        /// </summary>
        public EntryViewModel<short> CardCVCCode { get; set; }

        #endregion

        #region Constructor

        public SponsorInfoViewModel()
        {

        }

        #endregion
    }
}
