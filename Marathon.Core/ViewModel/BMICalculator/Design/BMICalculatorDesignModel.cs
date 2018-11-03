namespace Marathon.Core.ViewModel.BMICalculator.Design
{
    /// <summary>
    /// The design-time data for a <see cref="BMICalculatorViewModel"/>
    /// </summary>
    public class BMICalculatorDesignModel : BMICalculatorViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static BMICalculatorDesignModel Instance => new BMICalculatorDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BMICalculatorDesignModel()
        {
            Growth.Value = 170;
            Weight.Value = 70;

            Result = new BMIResultDesignModel();
        }

        #endregion
    }
}
