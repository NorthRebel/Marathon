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
        /// Title of the options list
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Items of list
        /// </summary>
        public IEnumerable<MarathonOptionsItemViewModel> Items { get; set; }
    }
}
