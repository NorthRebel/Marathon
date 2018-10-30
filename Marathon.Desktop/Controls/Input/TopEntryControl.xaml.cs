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

namespace Marathon.Desktop.Controls.Input
{
    /// <summary>
    /// Логика взаимодействия для TopEntryControl.xaml
    /// </summary>
    public partial class TopEntryControl : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// Vertically aligns inner content of control
        /// </summary>
        public VerticalAlignment InnerContentVerticalAlignment
        {
            get => (VerticalAlignment)GetValue(ContentHorizontalAlignmentProperty);
            set => SetValue(ContentHorizontalAlignmentProperty, value);
        }

        public static readonly DependencyProperty ContentHorizontalAlignmentProperty =
            DependencyProperty.Register(nameof(InnerContentVerticalAlignment), typeof(VerticalAlignment), typeof(TopEntryControl),
                new PropertyMetadata(VerticalAlignment.Center, VerticalAlignmentPropertyChanged));

        #endregion

        public TopEntryControl()
        {
            InitializeComponent();
        }

        #region Dependency Helpers

        private static void VerticalAlignmentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var entryControl = d as TopEntryControl;

            if (entryControl.ApplyTemplate())
            {
                var contentPresenter = entryControl.Template.FindName("InputContent", entryControl) as ContentPresenter;
                contentPresenter.VerticalAlignment = (VerticalAlignment)e.NewValue;
            }
        }

        #endregion
    }
}
