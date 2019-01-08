using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.RunnerInfoManage.SignUpStatus
{
    /// <summary>
    /// The view model for a runner's sign up statuses list item
    /// </summary>
    public class SignUpStatusListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Name of status
        /// </summary>
        public string StatusName { get; set; }

        /// <summary>
        /// Check status flag
        /// </summary>
        public bool Value { get; set; }
    }
}
