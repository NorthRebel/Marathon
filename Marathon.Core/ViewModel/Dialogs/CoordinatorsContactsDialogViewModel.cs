using System.Collections.Generic;
using Marathon.Core.ViewModel.Input;

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
        /// Contact of coordinators
        /// </summary>
        public IEnumerable<EntryViewModel<string>> Contacts { get; set; }

        #endregion

        #region Constructor

        public CoordinatorsContactsDialogViewModel()
        {

        }

        #endregion
    }
}
