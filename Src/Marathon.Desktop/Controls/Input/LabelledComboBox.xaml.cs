﻿using System;
using System.Linq;
using System.Windows;
using System.Collections;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Controls;

namespace Marathon.Desktop.Controls.Input
{
    /// <summary>
    /// Interaction logic for LabelledComboBox.xaml
    /// </summary>
    public partial class LabelledComboBox : UserControl, IDataErrorInfo
    {
        #region Dependency Properties

        #region Label

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(string), typeof(LabelledComboBox),
                new FrameworkPropertyMetadata("Unnamed Label"));

        #endregion

        #region ComboBox

        public IEnumerable Items
        {
            get => (IEnumerable)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(nameof(Items), typeof(IEnumerable), typeof(LabelledComboBox),
                new FrameworkPropertyMetadata(default(IEnumerable)));


        public object SelectedItem
        {
            get => (object)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(LabelledComboBox),
                new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        public object SelectedValue
        {
            get => (object)GetValue(SelectedValueProperty);
            set => SetValue(SelectedValueProperty, value);
        }

        public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.Register(nameof(SelectedValue), typeof(object), typeof(LabelledComboBox),
                new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        
        public string DisplayMember
        {
            get => (string)GetValue(DisplayMemberProperty);
            set => SetValue(DisplayMemberProperty, value);
        }

        public static readonly DependencyProperty DisplayMemberProperty =
            DependencyProperty.Register(nameof(DisplayMember), typeof(string), typeof(LabelledComboBox), 
                new FrameworkPropertyMetadata(default(string)));

        
        public string ValueMember
        {
            get => (string)GetValue(ValueMemberProperty);
            set => SetValue(ValueMemberProperty, value);
        }

        public static readonly DependencyProperty ValueMemberProperty =
            DependencyProperty.Register(nameof(ValueMember), typeof(string), typeof(LabelledComboBox), 
                new FrameworkPropertyMetadata(default(string)));

        #endregion

        #endregion

        public LabelledComboBox()
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
