using System.Windows;
using System.Windows.Controls;

namespace Marathon.Desktop.Controls.Input
{
    /// <summary>
    /// Interaction logic for LabelledTextBlock.xaml
    /// </summary>
    public partial class LabelledTextBlock : UserControl
    {
        #region Dependency Properties

        #region Label

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(string), typeof(LabelledTextBlock),
                new FrameworkPropertyMetadata("Unnamed Label"));

        #endregion

        #region Text

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(LabelledTextBlock),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        #endregion

        #endregion

        public LabelledTextBlock()
        {
            InitializeComponent();
            Root.DataContext = this;
        }
    }
}
