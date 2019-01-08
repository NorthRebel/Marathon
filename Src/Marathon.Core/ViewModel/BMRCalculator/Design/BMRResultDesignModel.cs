using System.Collections.Generic;
using Marathon.Core.ViewModel.BMRCalculator.Models;

namespace Marathon.Core.ViewModel.BMRCalculator.Design
{
    /// <summary>
    /// The design-time data for a <see cref="BMRResultViewModel"/>
    /// </summary>
    public class BMRResultDesignModel : BMRResultViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static BMRResultDesignModel Instance => new BMRResultDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BMRResultDesignModel()
        {
            Value = 1.670;

            WastedCalories = new[]
            {
                new KeyValuePair<ActivityLevel, LifestyleWasteCalories>(ActivityLevel.Sitting,
                    new LifestyleWasteCalories("Сидячий", 1.2, "FF0000FF") {Value = 2.004}),
                new KeyValuePair<ActivityLevel, LifestyleWasteCalories>(ActivityLevel.SmallActivity,
                    new LifestyleWasteCalories("Маленькая активность", 1.375, "FFADFF2F") {Value = 2.296}),
                new KeyValuePair<ActivityLevel, LifestyleWasteCalories>(ActivityLevel.MediumActivity,
                    new LifestyleWasteCalories("Средняя активность", 1.55, "FFFFD700") {Value = 2.589}),
                new KeyValuePair<ActivityLevel, LifestyleWasteCalories>(ActivityLevel.StrongActivity,
                    new LifestyleWasteCalories("Сильная активность", 1.725, "FFFF0000"){Value = 2.881}),
                new KeyValuePair<ActivityLevel, LifestyleWasteCalories>(ActivityLevel.MaxActivity,
                    new LifestyleWasteCalories("Максимальная  активность", 1.9, "FF8B0000"){Value = 3.173}),
            };
        }

        #endregion
    }
}
