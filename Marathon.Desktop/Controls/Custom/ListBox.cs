using System.Windows;
using System.Collections;

namespace Marathon.Desktop.Controls.Custom
{
    /// <summary>
    /// Custom version of listbox that allows to bind to list of selected items
    /// </summary>
    public class ListBox : System.Windows.Controls.ListBox
    {
        public ListBox()
        {
            SelectionChanged += ListBox_SelectionChanged;
        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SelectedItemsList = SelectedItems;
        }

        public IList SelectedItemsList
        {
            get => (IList)GetValue(SelectedItemsListProperty);
            set => SetValue(SelectedItemsListProperty, value);
        }

        public static readonly DependencyProperty SelectedItemsListProperty =
            DependencyProperty.Register("SelectedItemsList", typeof(IList), typeof(ListBox), new PropertyMetadata(null));
    }
}
