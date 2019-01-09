using System.Collections.Generic;

namespace Marathon.Core.ViewModel.Dialogs
{
    /// <summary>
    /// The view model for a coordinators contacts dialog
    /// </summary>
    public class CoordinatorsContactsDialogViewModel : BaseDialogViewModel
    {
        #region Public Properties

        /// <summary>
        /// The message to display
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Contact of coordinators where Key is coordinator's contact type, Value = info to contact 
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> Contacts { get; set; }

        #endregion

        #region Constructor

        public CoordinatorsContactsDialogViewModel()
        {

        }

        #endregion
    }
}
