using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.SignUpToMarathon
{
    /// <summary>
    /// The view model for a SignUpToMarathon page
    /// </summary>
    public class SignUpToMarathonViewModel : SignedInViewModel
    {
        #region Public Properties

        /// <summary>
        /// Caption and description info about current page
        /// </summary>
        public PageCaptionViewModel PageCaption { get; set; }

        #endregion

        #region Constructor

        public SignUpToMarathonViewModel()
        {
            PageCaption = new PageCaptionViewModel
            {
                Caption = "Регистрация на марафон",
                Description = "Пожалуйста, заполните всю информацию, чтобы зарегистрироваться на Skills Marathon 2016 проводимом в Москве. Россия. " +
                              "С вами свяжутся после регистрации, для уточнения оплаты и другой информации."
            };
        }

        #endregion
    }
}
