using Marathon.Core.ViewModel.MarathonOptions;

namespace Marathon.Core.ViewModel.SignUpToMarathon.Design
{
    /// <summary>
    /// The design-time data for a <see cref="SignUpToMarathonViewModel"/>
    /// </summary>
    public class SignUpToMarathonDesignModel : SignUpToMarathonViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SignUpToMarathonDesignModel Instance => new SignUpToMarathonDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SignUpToMarathonDesignModel()
        {
            SponsorshipDetails = SponsorshipDetailsDesignModel.Instance;
            PaymentDetail = PaymentSignInMarathonDesignModel.Instance;

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
                Items = new[]
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
        }

        #endregion
    }
}
