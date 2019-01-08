using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.RunnerInfoManage.SignUpStatus
{
    /// <summary>
    /// The view model for a runner's sign up statuses list
    /// </summary>
    public class SignUpStatusListViewModel : BaseViewModel
    {
        /// <summary>
        /// Runner's sign up to marathon statues flags
        /// </summary>
        public IEnumerable<SignUpStatusListItemViewModel> Items { get; set; }
    }
}
