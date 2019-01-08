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

namespace Marathon.Desktop.Controls.BMICalculator.BMIResult.Scale
{
    /// <summary>
    /// Interaction logic for ScaleSegmentControl.xaml
    /// </summary>
    public partial class ScaleSegmentControl : UserControl
    {
        #region Dependency Properties

        #region Color of segment

        public Brush SegmentColor
        {
            get => (Brush)GetValue(SegmentColorProperty);
            set => SetValue(SegmentColorProperty, value);
        }

        public static readonly DependencyProperty SegmentColorProperty =
            DependencyProperty.Register(nameof(SegmentColor), typeof(Brush), typeof(ScaleSegmentControl),
                new PropertyMetadata(null, SegmentColorPropertyChanged));

        #endregion

        #region Description of segment
        
        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register(nameof(Description), typeof(string), typeof(ScaleSegmentControl), 
                new PropertyMetadata(null, DescriptionPropertyChanged));
        
        #endregion

        #endregion

        public ScaleSegmentControl()
        {
            InitializeComponent();
        }

        #region Dependency Helpers

        private static void SegmentColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ScaleSegmentControl segmentControl)
                segmentControl.SegmentRect.Fill = (Brush)e.NewValue;
        }

        private static void DescriptionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ScaleSegmentControl segmentControl)
                segmentControl.DescriptionText.Text = (string) e.NewValue;
        }

        #endregion
    }
}
