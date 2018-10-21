namespace Marathon.Core.ViewModel.SignUpToMarathon.Design
{
    /// <summary>
    /// The design-time data for a <see cref="CharityDetailViewModel"/>
    /// </summary>
    public class CharityDetailDesignModel : CharityDetailViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static CharityDetailDesignModel Instance => new CharityDetailDesignModel("Взнос");

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CharityDetailDesignModel(string label) : base(label)
        {
            Value = new string[]
            {
                "Фонд А",
                "Фонд Б",
                "Фонд В",
            };
        }

        #endregion
    }
}
