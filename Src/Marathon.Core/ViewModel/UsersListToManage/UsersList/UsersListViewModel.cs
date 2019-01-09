using System.Collections.Generic;
using System.Windows.Input;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.UsersListToManage.UsersList
{
    /// <summary>
    /// The view model for users list
    /// </summary>
    public class UsersListViewModel : BaseViewModel
    {
        /// <summary>
        /// List of signed up users
        /// </summary>
        public IEnumerable<UsersListItemViewModel> Items { get; set; }

        /// <summary>
        /// Count of <see cref="Items"/>
        /// </summary>
        public long ItemsCount { get; set; }

        /// <summary>
        /// Edit selected user from <see cref="Items"/>
        /// </summary>
        public ICommand EditUserCommand { get; set; }
    }
}
