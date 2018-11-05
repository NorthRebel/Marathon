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
    /// Логика взаимодействия для LeftEntryControl.xaml
    /// </summary>
    public partial class LeftEntryControl : UserControl
    {
        #region Dependency Properties

        public FontWeight LabelWeight
        {
            get => (FontWeight)GetValue(LabelWeightProperty);
            set => SetValue(LabelWeightProperty, value);
        }

        public static readonly DependencyProperty LabelWeightProperty =
            DependencyProperty.Register(nameof(LabelWeight), typeof(FontWeight), typeof(LeftEntryControl),
                new PropertyMetadata(default(FontWeight), LabelWeightPropertyChanged));
       
        #endregion

        public LeftEntryControl()
        {
            InitializeComponent();
        }

        #region Dependency Helpers

        private static void LabelWeightPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LeftEntryControl entryControl)
            {
                if (entryControl.ApplyTemplate())
                {
                    var entryLabel = entryControl.Template.FindName("EntryLabel", entryControl) as TextBlock;
                    entryLabel.FontWeight = (FontWeight) e.NewValue;
                }
            }
        }

        #endregion
    }
}
