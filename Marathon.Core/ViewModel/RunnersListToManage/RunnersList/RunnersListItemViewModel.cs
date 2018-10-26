using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.RunnersListToManage.RunnersList
{
    /// <summary>
    /// The view model for runners list item
    /// </summary>
    public class RunnersListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Runner's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Runner's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Runner's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Runner's sign up to marathon status
        /// </summary>
        public string Status { get; set; }
    }
}
