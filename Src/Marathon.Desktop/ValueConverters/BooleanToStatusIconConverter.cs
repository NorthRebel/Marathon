using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Marathon.Desktop.ValueConverters
{
    /// <summary>
    /// A converter that takes in a boolean and returns an <see cref="Uri"/> of runner's sign up status icon
    /// </summary>
    public class BooleanToStatusIconConverter : BaseValueConverter<BooleanToStatusIconConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool statusValue))
                return null;

            return statusValue ? new Uri($"pack://application:,,,/Resources/Images/StatusIcons/tick-icon.png") : 
                new Uri("pack://application:,,,/Resources/Images/StatusIcons/cross-icon.png");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
