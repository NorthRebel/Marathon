namespace Marathon.Core.ViewModel.BMRCalculator.Design
{
    /// <summary>
    /// The design-time data for a <see cref="BMRCalculatorViewModel"/>
    /// </summary>
    public class BMRCalculatorDesignModel : BMRCalculatorViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static BMRCalculatorDesignModel Instance => new BMRCalculatorDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BMRCalculatorDesignModel()
        {
            Growth.Value = 180;
            Weight.Value = 70;
            Age.Value = 30;

            Result = new BMRResultDesignModel();
        }

        #endregion
    }
}
