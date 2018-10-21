using System.Windows.Input;
using Marathon.Core.Models;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.AboutMarathon
{
    /// <summary>
    /// The view model for a AboutMarathon page
    /// </summary>
    public class AboutMarathonViewModel : PageViewModel
    {
        #region Public Properties

        /// <summary>
        /// Additional info about marathon
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Image of interactive map of marathon
        /// </summary>
        public byte[] InteractiveMapImage { get; set; }

        // TODO: Try to change this to collection of photos
        #region Images of marathon
      
        public byte[] MarathonImage1 { get; set; }

        public byte[] MarathonImage2 { get; set; }

        public byte[] MarathonImage3 { get; set; }

        public byte[] MarathonImage4 { get; set; }

        #endregion

        #endregion

        #region Commands

        /// <summary>
        /// Go to interactive map page of marathon
        /// </summary>
        public ICommand OpenInteractiveMapCommand { get; set; }

        #endregion

        #region Constructor

        public AboutMarathonViewModel()
        {
            OpenInteractiveMapCommand = new RelayCommand(x => GoToPage(ApplicationPage.InteractiveMap));

            PageCaption = new PageCaptionViewModel
            {
                Caption = "Информация о Marathon Skills 2016"
            };
        }

        #endregion

        #region Commands Helpers



        #endregion
    }
}
