using System.Windows.Input;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Input;
using Marathon.Core.ViewModel.ShowCertificate.Models;

namespace Marathon.Core.ViewModel.ShowCertificate
{
    /// <summary>
    /// The view model for show runner certificate page
    /// </summary>
    public class ShowCertificateViewModel : SignedInViewModel
    {
        #region Public Properties

        /// <summary>
        /// List of spent marathons that current runner take part 
        /// </summary>
        public ItemsEntryViewModel<string> Marathons { get; set; }

        /// <summary>
        /// List of marathon distances that current runner take part
        /// </summary>
        public ItemsEntryViewModel<string> Distances { get; set; }

        /// <inheritdoc cref="CertificateViewModel"/>
        public CertificateViewModel Certificate { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Show certificate for current runner of selected marathon and distance
        /// </summary>
        public ICommand ShowCertificateCommand { get; set; }

        #endregion

        #region Constructor

        public ShowCertificateViewModel()
        {
            Marathons = new ItemsEntryViewModel<string>("Марафон");
            Distances = new ItemsEntryViewModel<string>("Вид марафона");

            ShowCertificateCommand = new RelayCommand(ShowRunnerCertificate);
        }

        #endregion

        #region Command Helpers

        private void ShowRunnerCertificate(object obj)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
