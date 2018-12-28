using System.Windows;
using System.Collections;
using System.Windows.Controls;

namespace Marathon.Desktop.Controls.MarathonOptions
{
    /// <summary>
    /// Interaction logic for MarathonOptionsMultiple.xaml
    /// </summary>
    public partial class MarathonOptionsMultiple : UserControl
    {
        #region Dependency Properties
        
        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable), typeof(MarathonOptionsMultiple), 
                new PropertyMetadata(default(IEnumerable)));

        
        public IList SelectedItems
        {
            get => (IList)GetValue(SelectedItemsProperty);
            set => SetValue(SelectedItemsProperty, value);
        }

        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register(nameof(SelectedItems), typeof(IList), typeof(MarathonOptionsMultiple), 
                new PropertyMetadata(default(IList)));

        #endregion

        public MarathonOptionsMultiple()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
