using System.Collections.Generic;

namespace Marathon.Core.ViewModel.Dialogs
{
    /// <summary>
    /// The view model for a about activity levels dialog
    /// </summary>
    public class AboutActivityLevelsDialogViewModel : BaseDialogViewModel
    {
        /// <summary>
        /// Activity levels with description where Key is name, Value - description
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> ActivityLevels { get; set; }
    }
}
