namespace Marathon.Core.ViewModel.ShowCertificate.Design
{
    /// <summary>
    /// The design-time data for a <see cref="ShowCertificateViewModel"/>
    /// </summary>
    public class ShowCertificateDesignModel : ShowCertificateViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ShowCertificateDesignModel Instance => new ShowCertificateDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ShowCertificateDesignModel()
        {
            Marathons = new[]
            {
                "2014 - Japan",
                "2015 - Berlin"
            };

            Distances = new[]
            {
                "42km Полный марафон",
                "21km Полумарафон",
                "5km Малая дистанция"
            };

            Certificate = new CertificateDesignModel();
        }

        #endregion
    }
}
