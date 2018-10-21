using System;
using System.Collections.Generic;
using Marathon.Core.ViewModel.Input;

namespace Marathon.Core.ViewModel.SponsorRunner.Design
{
    /// <summary>
    /// The design-time data for a <see cref="SponsorInfoViewModel"/>
    /// </summary>
    public class SponsorInfoDesignModel : SponsorInfoViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SponsorInfoDesignModel Instance => new SponsorInfoDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SponsorInfoDesignModel()
        {
            Title = "Информация о Спонсоре";

            Name = new EntryViewModel<string>("Имя");
            Runner = new EntryViewModel<IEnumerable<string>>("Бегун")
            {
                Value = new[]
                {
                    "Kyle Verberder - 122 (Germany)",
                    "Migel Oriviera - 159 (Spain)",
                    "Иван Прудов - 204 (Russia)",
                    "Julie Lawet - 007 (France)",
                }
            };

            CardHolder = new EntryViewModel<string>("Карта");
            CardNumber = new EntryViewModel<long>("Номер карты");
            CardValidity = new EntryViewModel<DateTimeOffset>("Срок действия")
            {
                Value = DateTimeOffset.Now
            };

            CardCVCCode = new EntryViewModel<short>("CVC");
        }

        #endregion
    }
}
