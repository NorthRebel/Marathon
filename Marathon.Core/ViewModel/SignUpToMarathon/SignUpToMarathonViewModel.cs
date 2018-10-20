using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.MarathonOptions;
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

        /// <summary>
        /// Types of marathon for take part them
        /// </summary>
        public MarathonOptionsViewModel MarathonTypes { get; set; }

        /// <summary>
        /// Types of race kit which runner can use it in marathon
        /// </summary>
        public MarathonOptionsViewModel RaceKits { get; set; }

        /// <summary>
        /// Details which means payment amount for charity organization 
        /// </summary>
        public SponsorshipDetailsViewModel SponsorshipDetails { get; set; }

        /// <summary>
        /// Indicates sum of price of selected RaceKits and MarathonType
        /// </summary>
        public PaymentSignInMarathonViewModel PaymentDetail { get; set; }

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

            // TODO: Remove dummy data

            #region Fill dummy data to viewModel
            
            MarathonTypes = new MarathonOptionsViewModel
            {
                Title = "Вид марафона",
                Items = new[]
                {
                    new MarathonOptionsItemViewModel
                    {
                        IsSelected = true,
                        Description = "42km Полный марафон($145)"
                    },
                    new MarathonOptionsItemViewModel
                    {
                        IsSelected = false,
                        Description = "21km Полумарафон ($75)"
                    },
                    new MarathonOptionsItemViewModel
                    {
                        IsSelected = true,
                        Description = "5km Малая дистанция ($20)"
                    }
                }
            };

            RaceKits = new MarathonOptionsViewModel
            {
                Title = "Варианты комплектов",
                Items = new []
                {
                    new MarathonOptionsItemViewModel
                    {
                        IsSelected = false,
                        Description = "Вариант A ($0): Номер бегуна + RFID браслет."
                    },
                    new MarathonOptionsItemViewModel
                    {
                        IsSelected = true,
                        Description = "Вариант B ($20): вариант A + бейсболка + бутылка воды."
                    },
                    new MarathonOptionsItemViewModel
                    {
                        IsSelected = false,
                        Description = "Вариант C ($45): Вариант B + футболка + сувенирный буклет."
                    }
                }
            };

            PaymentDetail = new PaymentSignInMarathonViewModel
            {
                Title = "Регистрационный взнос",
                Payment = 660
            };

            SponsorshipDetails = new SponsorshipDetailsViewModel();

            #endregion
        }

        #endregion
    }
}
