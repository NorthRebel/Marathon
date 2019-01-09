using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.VolunteersListToManage.VolunteersList
{
    /// <summary>
    /// The view model for volunteers list
    /// </summary>
    public class VolunteersListViewModel : BaseViewModel
    {
        /// <summary>
        /// List of volunteers
        /// </summary>
        public IEnumerable<VolunteersListItemViewModel> Items { get; set; }

        /// <summary>
        /// Count of <see cref="Items"/>
        /// </summary>
        public long ItemsCount { get; set; }
    }
}
