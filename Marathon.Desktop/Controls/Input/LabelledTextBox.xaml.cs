using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Marathon.Desktop.Controls.Input
{
    /// <summary>
    /// Interaction logic for LabelledTextBox.xaml
    /// </summary>
    public partial class LabelledTextBox : UserControl, IDataErrorInfo
    {
        #region Dependency Properties

        #region Label

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(string), typeof(LabelledTextBox),
                new FrameworkPropertyMetadata("Unnamed Label"));
        
        #endregion

        #region Text

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(LabelledTextBox),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        
        public string TextPlaceholder
        {
            get => (string)GetValue(TextPlaceholderProperty);
            set => SetValue(TextPlaceholderProperty, value);
        }

        public static readonly DependencyProperty TextPlaceholderProperty =
            DependencyProperty.Register(nameof(TextPlaceholder), typeof(string), typeof(LabelledTextBox), 
                new PropertyMetadata(default(object), TextPlaceholderChanged));

        #endregion

        #endregion

        public LabelledTextBox()
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

        #region Dependency properties Helpers

        private static void TextPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LabelledTextBox ctrl)
            {
                ctrl.EntryText.Tag = e.NewValue;
            }
        }

        #endregion
    }
}
