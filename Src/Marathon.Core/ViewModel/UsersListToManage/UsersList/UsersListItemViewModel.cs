using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.UsersListToManage.UsersList
{
    /// <summary>
    /// The view model for users list item
    /// </summary>
    public class UsersListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// User's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// User's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Type of user's privileges 
        /// </summary>
        public string UserType { get; set; }
    }
}
