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
                "42km Полный марафон($145)",
                "21km Полумарафон ($75)",
                "5km Малая дистанция ($20)"
            };

            RaceKits = new[]
            {
                "Вариант A ($0): Номер бегуна + RFID браслет.",
                "Вариант B ($20): вариант A + бейсболка + бутылка воды.",
                "Вариант C ($45): Вариант B + футболка + сувенирный буклет."
            };
        }

        #endregion
    }
}
