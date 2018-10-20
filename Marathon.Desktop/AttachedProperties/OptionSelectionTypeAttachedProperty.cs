using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Marathon.Desktop.Controls;
using Marathon.Desktop.Controls.MarathonOptions;
using Marathon.Desktop.Models;

namespace Marathon.Desktop.AttachedProperties
{
    /// <summary>
    /// Set selection type for marathon options list
    /// </summary>
    public class OptionSelectionTypeAttachedProperty : BaseAttachedProperty<OptionSelectionTypeAttachedProperty, OptionSelectionType>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Cast content to options list
            if (!(sender is MarathonOptionsListControl listControl))
                return;

            //var dataTemplate = listControl.Resources["ItemContentTempalte"] as DataTemplate;

            //var itemControl = dataTemplate.LoadContent() as MarathonOptionsItemControl;

            //itemControl.SelectionType = (OptionSelectionType?)e.NewValue;

            //if (!(listControl.Content is ScrollViewer scrollViewer))
            //    return;

            //scrollViewer.ContentTemplate = dataTemplate;
        }
    }
}