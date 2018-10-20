﻿using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Input;

namespace Marathon.Core.ViewModel.SignUpToMarathon
{
    /// <summary>
    /// The view model for a sponsorship details part of SignUpToMarathon page
    /// </summary>
    public class SponsorshipDetailsViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Title of the options list
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// List of charity for sponsorship
        /// </summary>
        public EntryViewModel<IEnumerable<string>> CharityDetail { get; set; }

        /// <summary>
        /// Sponsorship amount for charity organization
        /// </summary>
        public EntryViewModel<decimal> SponsorshipAmount { get; set; }

        #endregion

        #region Constructor

        public SponsorshipDetailsViewModel()
        {
            Title = "Детали спонсорства";

            // TODO: Remove dummy data

            #region Fill dummy data to viewModel

            CharityDetail = new EntryViewModel<IEnumerable<string>>("Взнос")
            {
                Value = new string[]
                {
                    "Фонд А",
                    "Фонд Б",
                    "Фонд В",
                }
            };

            SponsorshipAmount = new EntryViewModel<decimal>("Сумма взноса")
            {
                Value = 500
            };

            #endregion
        }

        #endregion
    }
}
