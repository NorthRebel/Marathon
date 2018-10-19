using System;
using System.Globalization;

namespace Marathon.Desktop.ValueConverters
{
    /// <summary>
    /// A converter that takes value and divide them by parameter value
    /// </summary>
    public class DivValueConverter : BaseValueConverter<DivValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dividend = System.Convert.ToDouble(value);
            var divider = System.Convert.ToDouble(parameter);

            return dividend / divider;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
