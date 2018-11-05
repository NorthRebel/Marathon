using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.Input
{
    /// <summary>
    /// The view model for a entry with label to edit contains content
    /// <summary>
    /// <typeparam name="T">Type of entry value</typeparam>
    public class EntryViewModel<T> : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Value of input content
        /// </summary>
        public virtual T Value { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Entry without label can't exists
        /// </summary>
        /// <param name="label">Label of the entry</param>
        public EntryViewModel(string label)
        {
            Label = label;
        }

        #endregion
    }
}
