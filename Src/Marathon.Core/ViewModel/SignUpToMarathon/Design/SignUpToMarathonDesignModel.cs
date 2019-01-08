using Marathon.Core.Models.Marathon;
using Marathon.Core.Models.RaceKit;

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

            MarathonTypesToSelect = new[]
            {
                new EventType
                {
                    Id = "FM",
                    Name = "Полный марафон"
                },
                new EventType
                {
                    Id = "HM",
                    Name = "Полумарафон"
                },
                new EventType
                {
                    Id = "SM",
                    Name = "Малая дистанция"
                }
            };

            RaceKits = new[]
            {
                new RaceKit
                {
                    Id = 'A',
                    Name = "Номер бегуна + RFID браслет",
                    Cost = 0m
                },
                new RaceKit
                {
                    Id = 'B',
                    Name = "Вариант A + бейсболка + бутылка воды",
                    Cost = 20m
                },
                new RaceKit
                {
                    Id = 'C',
                    Name = "Вариант B + футболка + сувенирный буклет",
                    Cost = 45m
                }
            };
        }

        #endregion
    }
}
