using System.Collections.Generic;
using Marathon.Core.ViewModel.Input;

namespace Marathon.Core.ViewModel.Dialogs
{
    /// <summary>
    /// The view model for a about activity levels dialog
    /// </summary>
    public class AboutActivityLevelsDialogViewModel : BaseDialogViewModel
    {
        /// <summary>
        /// Activity levels with description
        /// </summary>
        public IEnumerable<EntryViewModel<string>> ActivityLevels { get; set; }
    }
}
