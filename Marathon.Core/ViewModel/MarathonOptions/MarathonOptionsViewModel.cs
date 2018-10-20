using System.Collections.Generic;

namespace Marathon.Core.ViewModel.MarathonOptions
{
    /// <summary>
    /// The view model for a marathon options items list
    /// </summary>
    public class MarathonOptionsViewModel : OptionsViewModel
    {
        /// <summary>
        /// Items of list
        /// </summary>
        public IEnumerable<MarathonOptionsItemViewModel> Items { get; set; }
    }
}
