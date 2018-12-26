using System.Windows;
using System.Collections;
using System.Windows.Controls;

namespace Marathon.Desktop.Controls.MarathonOptions
{
    /// <summary>
    /// Interaction logic for MarathonOptionsSingle.xaml
    /// </summary>
    public partial class MarathonOptionsSingle : UserControl
    {
        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable), typeof(MarathonOptionsSingle),
                new FrameworkPropertyMetadata(default(IEnumerable)));

        public object SelectedItem
        {
            get => (object)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(MarathonOptionsSingle),
                new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        public MarathonOptionsSingle()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
