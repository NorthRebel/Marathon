using System.Windows;
using System.Windows.Controls;

namespace Marathon.Desktop.Controls
{
    /// <summary>
    /// Логика взаимодействия для MarathonOptionsControl.xaml
    /// </summary>
    public partial class MarathonOptionsControl : UserControl
    {
        #region Dependency Properties

        #region Horizontal alignment

        /// <summary>
        /// Horizontally aligns inner content of control
        /// </summary>
        public HorizontalAlignment ContentHorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(ContentHorizontalAlignmentProperty);
            set => SetValue(ContentHorizontalAlignmentProperty, value);
        }

        public static readonly DependencyProperty ContentHorizontalAlignmentProperty =
            DependencyProperty.Register(nameof(ContentHorizontalAlignment), typeof(HorizontalAlignment), typeof(MarathonOptionsControl),
                new PropertyMetadata(HorizontalAlignment.Left, HorizontalAlignmentPropertyChanged));

        #endregion

        #region Title

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(MarathonOptionsControl),
                new FrameworkPropertyMetadata("Unnamed Title"));

        #endregion

        #endregion

        public MarathonOptionsControl()
        {
            InitializeComponent();
            Root.DataContext = this;
        }

        #region Dependency Helpers

        private static void HorizontalAlignmentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MarathonOptionsControl ctrl)
            {
                if (ctrl.Template.FindName("OptionsContent", ctrl) is ContentPresenter contentPresenter)
                    contentPresenter.HorizontalAlignment = (HorizontalAlignment)e.NewValue;
            }
        }

        #endregion
    }
}
