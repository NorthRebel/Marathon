using System.Windows;
using System.Windows.Controls;

namespace Marathon.Desktop.Controls.BMICalculator
{
    /// <summary>
    /// Interaction logic for EntryControl.xaml
    /// </summary>
    public partial class EntryControl : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// Unit which explains entry value
        /// </summary>
        public string Unit
        {
            get => (string)GetValue(UnitProperty);
            set => SetValue(UnitProperty, value);
        }

        public static readonly DependencyProperty UnitProperty =
            DependencyProperty.Register(nameof(Unit), typeof(string), typeof(EntryControl),
                new FrameworkPropertyMetadata("Unnamed unit"));

        #region Label

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(string), typeof(EntryControl),
                new FrameworkPropertyMetadata("Unnamed Label"));

        #endregion

        #region Text

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(EntryControl),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        #endregion

        #endregion

        public EntryControl()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
