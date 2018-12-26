using System;
using System.Windows;
using System.Windows.Controls;

namespace Marathon.Desktop.Controls.Input
{
    /// <summary>
    /// Interaction logic for LabelledDatePicker.xaml
    /// </summary>
    public partial class LabelledDatePicker : UserControl
    {
        #region Dependency Properties

        #region Label

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(string), typeof(LabelledDatePicker),
                new FrameworkPropertyMetadata("Unnamed Label"));

        #endregion

        #region DatePicker
        
        public DateTime? Date
        {
            get => (DateTime?)GetValue(DateProperty);
            set => SetValue(DateProperty, value);
        }

        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register(nameof(Date), typeof(DateTime?), typeof(LabelledDatePicker), 
                new FrameworkPropertyMetadata(default(DateTime?), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        #endregion

        #endregion

        public LabelledDatePicker()
        {
            InitializeComponent();
            Root.DataContext = this;
        }
    }
}
