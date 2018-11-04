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
    /// Interaction logic for PointerControl.xaml
    /// </summary>
    public partial class PointerControl : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// Value of above pointer
        /// </summary>
        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(string), typeof(PointerControl),
                new PropertyMetadata(null, PointerValuePropertyChanged));

        #endregion

        public PointerControl()
        {
            InitializeComponent();
        }

        #region Dependency Helpers

        private static void PointerValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PointerControl pc)
                pc.PointerValueText.Text = (string)e.NewValue;
        }

        #endregion
    }
}
