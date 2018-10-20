using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Marathon.Desktop.Controls
{
    /// <summary>
    /// Логика взаимодействия для MarathonOptionsControl.xaml
    /// </summary>
    public partial class MarathonOptionsControl : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// Horizontally aligns inner content of control
        /// </summary>
        public HorizontalAlignment ContentHorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(ContentHorizontalAlignmentProperty);
            set => SetValue(ContentHorizontalAlignmentProperty, value);
        }

        public static readonly DependencyProperty ContentHorizontalAlignmentProperty =
            DependencyProperty.Register("ContentHorizontalAlignment", typeof(HorizontalAlignment), typeof(MarathonOptionsControl),
                new PropertyMetadata(HorizontalAlignment.Left, HorizontalAlignmentPropertyChanged));

        #endregion

        public MarathonOptionsControl()
        {
            InitializeComponent();
        }

        #region Dependency Helpers

        private static void HorizontalAlignmentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var optionsControl = d as MarathonOptionsControl;

            if (optionsControl.ApplyTemplate())
            {
                var contentPresenter = optionsControl.Template.FindName("OptionsContent", optionsControl) as ContentPresenter;
                contentPresenter.HorizontalAlignment = (HorizontalAlignment) e.NewValue;
            }
        }

        #endregion
    }
}
