using System;
using System.Globalization;

namespace Marathon.Desktop.ValueConverters
{
    /// <summary>
    /// A converter that takes runner completion time of marathon and converts it to specific format
    /// </summary>
    public class MarathonResultTimeConverter : BaseValueConverter<MarathonResultTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the time passed in
            var time = (TimeSpan)value;

            // Return a time span specific format
            return string.Format(@"{0:%h}h {0:mm}m {0:ss}s", time);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
