using Marathon.Core.ViewModel.HowLongMarathon.Models;
using Marathon.Core.ViewModel.HowLongMarathon.ItemsList.Design;

namespace Marathon.Core.ViewModel.HowLongMarathon.Design
{
    /// <summary>
    /// The design-time data for a <see cref="HowLongMarathonViewModel"/>
    /// </summary>
    public class HowLongMarathonDesignModel : HowLongMarathonViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static HowLongMarathonDesignModel Instance => new HowLongMarathonDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public HowLongMarathonDesignModel() : base(new MarathonDistance(42))
        {
            ItemsToCompare = new[]
            {
                new HowLongMarathonItemsListDesignModel() {Caption = "Скорость"},
                new HowLongMarathonItemsListDesignModel() { Caption = "Дистаниция"}
            };

            SelectedItem = new HowLongMarathonItemDesignModel();
        }

        #endregion
    }
}
