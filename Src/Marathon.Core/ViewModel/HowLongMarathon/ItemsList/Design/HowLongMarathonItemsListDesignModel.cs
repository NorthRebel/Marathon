namespace Marathon.Core.ViewModel.HowLongMarathon.ItemsList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="HowLongMarathonItemsListViewModel"/>
    /// </summary>
    public class HowLongMarathonItemsListDesignModel : HowLongMarathonItemsListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static HowLongMarathonItemsListDesignModel Instance => new HowLongMarathonItemsListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public HowLongMarathonItemsListDesignModel()
        {
            Caption = "Скорость";

            Items = new[]
            {
                new HowLongMarathonItemDesignModel(),
                new HowLongMarathonItemDesignModel(),
                new HowLongMarathonItemDesignModel(),
                new HowLongMarathonItemDesignModel(),
                new HowLongMarathonItemDesignModel(),
            };
        }

        #endregion
    }
}
