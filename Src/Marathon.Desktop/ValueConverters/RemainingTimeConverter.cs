using System;
using System.Globalization;

namespace Marathon.Desktop.ValueConverters
{
    /// <summary>
    /// A converter that takes in remaining date to begin of the marathon and converts it to string value
    /// </summary>
    public class RemainingTimeConverter : BaseValueConverter<RemainingTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            // Get the time passed in
            var time = (TimeSpan)value;

            return $"{time.Days} дней {time.Hours} часов и {time.Minutes} минут до старта марафона!";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
