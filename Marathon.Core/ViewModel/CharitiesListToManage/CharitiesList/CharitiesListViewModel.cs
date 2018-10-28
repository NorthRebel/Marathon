using System.Collections.Generic;
using System.Windows.Input;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.CharitiesListToManage.CharitiesList
{
    /// <summary>
    /// The view model for charities list
    /// </summary>
    public class CharitiesListViewModel : BaseViewModel
    {
        /// <summary>
        /// List of charities
        /// </summary>
        public IEnumerable<CharitiesListItemViewModel> Items { get; set; }

        /// <summary>
        /// Edit selected charity from <see cref="Items"/>
        /// </summary>
        public ICommand EditCharityCommand { get; set; }
    }
}
