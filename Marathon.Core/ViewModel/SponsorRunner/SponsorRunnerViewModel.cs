using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.SponsorRunner
{
    /// <summary>
    /// The view model for a SponsorRunner page
    /// </summary>
    public class SponsorRunnerViewModel : PageViewModel
    {
        #region Public Properties

        /// <summary>
        /// Credentials of sponsor
        /// </summary>
        public SponsorInfoViewModel SponsorInfo { get; set; }

        /// <summary>
        /// Charity of selected runner
        /// </summary>
        public RunnerCharityViewModel RunnerCharity { get; set; }

        /// <summary>
        /// Amount to sponsor runner
        /// </summary>
        public SponsorshipAmountViewModel SponsorshipAmount { get; set; }

        #endregion

        #region Constructor

        public SponsorRunnerViewModel()
        {
            PageCaption = new PageCaptionViewModel
            {
                Caption = "Спонсор бегуна",
                Description = "Пожалуйста выберите бегуна, которого вы отели бы спонсировать и сумму, которую вы хотели бы спонсировать. " +
                              "Спасибо за вашу поддержку бегунов и их благотворительных учреждений."
            };
        }

        #endregion
    }
}
