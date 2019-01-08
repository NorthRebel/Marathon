using System;
using System.Globalization;

namespace Marathon.Desktop.ValueConverters
{
    /// <summary>
    /// A converter that takes in date and converts it to a user friendly time
    /// </summary>
    public class TimeToDisplayTimeConverter : BaseValueConverter<TimeToDisplayTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the time passed in
            var time = (DateTimeOffset)value;

            // Return a full date
            return time.ToLocalTime().ToString("D");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
