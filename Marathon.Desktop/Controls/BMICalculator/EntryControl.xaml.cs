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

namespace Marathon.Desktop.Controls.BMICalculator
{
    /// <summary>
    /// Interaction logic for EntryControl.xaml
    /// </summary>
    public partial class EntryControl : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// Unit which explains entry value
        /// </summary>
        public string Unit
        {
            get => (string)GetValue(UnitProperty);
            set => SetValue(UnitProperty, value);
        }

        public static readonly DependencyProperty UnitProperty =
            DependencyProperty.Register(nameof(Unit), typeof(string), typeof(EntryControl),
                new PropertyMetadata(null, UnitTextPropertyChanged));

        #endregion

        public EntryControl()
        {
            InitializeComponent();
        }

        #region Dependency Helpers

        private static void UnitTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is EntryControl entryCtrl)
                entryCtrl.UnitText.Text = (string) e.NewValue;
        }

        #endregion
    }
}
