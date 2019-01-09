using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.VolunteersListToManage.Models
{
    /// <summary>
    /// Selected values of volunteer attributes
    /// </summary>
    public class ManageVolunteersCondition : BaseViewModel
    {
        /// <summary>
        /// Country name which volunteer from
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Volunteer's gender
        /// </summary>
        public string Gender { get; set; }
    }
}
