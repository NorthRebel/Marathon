using System.Windows;
using System.Windows.Controls;

namespace Marathon.Desktop.Controls.Input
{
    /// <summary>
    /// Interaction logic for LabelledTextBox.xaml
    /// </summary>
    public partial class LabelledTextBox : UserControl
    {
        #region Dependency Properties

        #region Label

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(string), typeof(LabelledTextBox),
                new FrameworkPropertyMetadata("Unnamed Label"));
        
        #endregion

        #region Text

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(LabelledTextBox),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        
        public string TextPlaceholder
        {
            get => (string)GetValue(TextPlaceholderProperty);
            set => SetValue(TextPlaceholderProperty, value);
        }

        public static readonly DependencyProperty TextPlaceholderProperty =
            DependencyProperty.Register(nameof(TextPlaceholder), typeof(string), typeof(LabelledTextBox), 
                new PropertyMetadata(default(object), TextPlaceholderChanged));

        #endregion

        #endregion

        public LabelledTextBox()
        {
            InitializeComponent();
            Root.DataContext = this;
        }

        #region Dependency properties Helpers

        private static void TextPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LabelledTextBox ctrl)
            {
                ctrl.EntryText.Tag = e.NewValue;
            }
        }

        #endregion
    }
}
