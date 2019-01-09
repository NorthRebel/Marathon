using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.HowLongMarathon.ItemsList.Items.Models;

namespace Marathon.Core.ViewModel.HowLongMarathon.ItemsList.Items
{
    /// <summary>
    /// The view model for a how long marathon item
    /// </summary>
    public class HowLongMarathonItemViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Image of item
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Name of item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value to compare how long is marathon regard self
        /// </summary>
        public double Value { get; set; }

        /// <inheritdoc cref="HowLongItemType"/>
        public HowLongItemType Type { get; set; }

        #endregion
    }
}
