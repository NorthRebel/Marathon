using System;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Controls;

namespace Marathon.Desktop.Controls.Input
{
    /// <summary>
    /// Interaction logic for LabelledDatePicker.xaml
    /// </summary>
    public partial class LabelledDatePicker : UserControl, IDataErrorInfo
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
        }

        #region IDataErrorInfo Members

        public string Error
        {
            get
            {
                if (Validation.GetHasError(this))
                    return string.Join(Environment.NewLine, Validation.GetErrors(this).Select(e => e.ErrorContent));

                return null;
            }
        }

        public string this[string columnName]
        {
            get
            {
                // use a specific validation or ask for UserControl Validation Error 
                if (Validation.GetHasError(this))
                {
                    var error = Validation.GetErrors(this)
                        .FirstOrDefault(e => ((BindingExpression)e.BindingInError).TargetProperty.Name == columnName);

                    if (error != null)
                        return error.ErrorContent as string;
                }

                return null;
            }
        }

        #endregion
    }
}
