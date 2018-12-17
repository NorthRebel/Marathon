using System.Collections.Generic;

namespace Marathon.Core.ViewModel.Input
{
    /// <summary>
    /// The view model for a entry list with label to edit contains content
    /// </summary>
    /// <typeparam name="T">Type of entry value</typeparam>
    public class ItemsEntryViewModel<T> : EntryViewModel<T>
    {
        /// <summary>
        /// Items to select
        /// </summary>
        public IEnumerable<T> Items { get; set; }

        public ItemsEntryViewModel(string label) : base(label)
        {
        }
    }
}
