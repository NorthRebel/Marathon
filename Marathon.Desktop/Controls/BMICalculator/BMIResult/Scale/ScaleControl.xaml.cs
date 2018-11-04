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
using Marathon.Core.ViewModel.BMICalculator;
using Marathon.Core.ViewModel.BMICalculator.Models;

namespace Marathon.Desktop.Controls.BMICalculator.BMIResult.Scale
{
    /// <summary>
    /// Interaction logic for ScaleControl.xaml
    /// </summary>
    public partial class ScaleControl : UserControl
    {
        private List<double> _segmentPositions;

        public ScaleControl()
        {
            InitializeComponent();

            Loaded += ScaleControl_Loaded;
        }

        private void ScaleControl_Loaded(object sender, RoutedEventArgs e)
        {           
            DrawScaleSegments();
        }

        /// <summary>
        /// Draw list of segments from view model
        /// </summary>
        private void DrawScaleSegments()
        {
            if (!(DataContext is BMIResultViewModel viewModel))
                return;

            _segmentPositions  = new List<double>();

            var columnWidth = new GridLength(1, GridUnitType.Star);

            int column = default(int);

            foreach (ScaleSegment segment in viewModel.Segments.OrderBy(s => s.MinValue))
            {
                ScaleSegments.ColumnDefinitions.Add(new ColumnDefinition { Width = columnWidth });

                var segmentControl = new ScaleSegmentControl();
                segmentControl.SetValue(Grid.ColumnProperty, column++);
                segmentControl.DescriptionText.Text = segment.Description;
                segmentControl.SegmentRect.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom($"#{segment.Background}"));

                ScaleSegments.Children.Add(segmentControl);
            }
        }
    }
}
