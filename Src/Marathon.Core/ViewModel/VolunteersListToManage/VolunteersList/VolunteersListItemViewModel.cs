using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.VolunteersListToManage.VolunteersList
{
    /// <summary>
    /// The view model for volunteers list item
    /// </summary>
    public class VolunteersListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Volunteer's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Volunteer's first name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Country name which volunteer from
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Volunteer's gender
        /// </summary>
        public string Gender { get; set; }
    }
}
