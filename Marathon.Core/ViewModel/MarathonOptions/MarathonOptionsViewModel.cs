using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.MarathonOptions
{
    /// <summary>
    /// The view model for a marathon options items list
    /// </summary>
    public class MarathonOptionsViewModel : BaseViewModel
    {
        /// <summary>
        /// Items of list
        /// </summary>
        public IEnumerable<MarathonOptionsItemViewModel> Items { get; set; }
    }
}
