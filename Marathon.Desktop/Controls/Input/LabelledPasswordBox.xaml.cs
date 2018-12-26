using System.Windows;
using System.Windows.Controls;

namespace Marathon.Desktop.Controls.Input
{
    /// <summary>
    /// Interaction logic for LabelledPasswordBox.xaml
    /// </summary>
    public partial class LabelledPasswordBox : UserControl
    {
        #region Dependency Properties

        #region Label

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(string), typeof(LabelledPasswordBox),
                new FrameworkPropertyMetadata("Unnamed Label"));

        #endregion

        #region Password

        public string PasswordPlaceholder
        {
            get => (string)GetValue(PasswordPlaceholderProperty);
            set => SetValue(PasswordPlaceholderProperty, value);
        }

        public static readonly DependencyProperty PasswordPlaceholderProperty =
            DependencyProperty.Register(nameof(PasswordPlaceholder), typeof(string), typeof(LabelledPasswordBox),
                new PropertyMetadata(default(object), PasswordPlaceholderChanged));

        #endregion

        #endregion

        public LabelledPasswordBox()
        {
            InitializeComponent();
            Root.DataContext = this;
        }

        #region Dependency properties Helpers

        private static void PasswordPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LabelledPasswordBox ctrl)
            {
                ctrl.PasswordText.Tag = e.NewValue;
            }
        }

        #endregion
    }
}
