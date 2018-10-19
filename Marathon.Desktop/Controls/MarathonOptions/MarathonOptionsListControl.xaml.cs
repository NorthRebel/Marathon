using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Marathon.Desktop.Models;

namespace Marathon.Desktop.Controls.MarathonOptions
{
    /// <summary>
    /// Логика взаимодействия для MarathonOptionsListControl.xaml
    /// </summary>
    public partial class MarathonOptionsListControl : UserControl
    {
        #region Private Members

        private const string RadioGroupName = "OptionsItemsGroup";

        #endregion

        #region Dependency Properties
        
        public OptionSelectionType SelectionType    
        {
            get => (OptionSelectionType)GetValue(SelectionTypeProperty);
            set => SetValue(SelectionTypeProperty, value);
        }
        

        public static readonly DependencyProperty SelectionTypeProperty =
            DependencyProperty.Register(nameof(SelectionType), typeof(OptionSelectionType), typeof(MarathonOptionsItemControl), new PropertyMetadata(OptionSelectionType.CheckBox, SelectionTypeCallBack));


        #endregion

        public MarathonOptionsListControl()
        {
            InitializeComponent();
        }

        #region Dependency Helpers

        private static void SelectionTypeCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var itemControl = d as MarathonOptionsItemControl;

            switch ((OptionSelectionType)e.NewValue)
            {
                case OptionSelectionType.CheckBox:
                    itemControl.RadioButtonControl.GroupName = string.Empty;
                    itemControl.ClearValue(RadioButton.IsCheckedProperty);
                    itemControl.RadioButtonControl.Visibility = Visibility.Collapsed;
                    break;
                case OptionSelectionType.RadioButton:
                    itemControl.RadioButtonControl.GroupName = RadioGroupName;
                    itemControl.ClearValue(CheckBox.IsCheckedProperty);
                    itemControl.CheckBoxControl.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        #endregion
    }
}
