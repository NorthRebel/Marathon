using System;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.ShowCertificate.Models
{
    /// <summary>
    /// The view model for a control which presents certificate about runner participation in marathon 
    /// </summary>
    public class CertificateViewModel : BaseViewModel
    {
        /// <summary>
        /// Marathon's logo of selected event
        /// </summary>
        public byte[] MarathonLogo { get; set; }

        /// <summary>
        /// Runner's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Runner's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Selected distance of marathon
        /// </summary>
        public string Distance { get; set; }

        /// <summary>
        /// Runner's completion time of selected event
        /// </summary>
        public TimeSpan CompletionTime { get; set; }

        /// <summary>
        /// Runner's occupied position of selected event
        /// </summary>
        public long OccupiedPosition { get; set; }

        /// <summary>
        /// Marathon's name
        /// </summary>
        public string MarathonName { get; set; }

        /// <summary>
        /// Location where marathon has spent
        /// </summary>
        public string MarathonLocation { get; set; }

        /// <summary>
        /// Earned amount by runner for charity organization
        /// </summary>
        public decimal EarnAmount { get; set; }
    }
}
