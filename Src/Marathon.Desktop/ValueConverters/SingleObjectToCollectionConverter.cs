using System;
using System.Globalization;
using System.Linq;

namespace Marathon.Desktop.ValueConverters
{
    /// <summary>
    /// A converter that takes in a single object and returns <see cref="IEnumerable<object>"/> with single element for DataGrid 
    /// </summary>
    public class SingleObjectToCollectionConverter : BaseValueConverter<SingleObjectToCollectionConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                throw new NullReferenceException();

            return Enumerable.Repeat(value, 1);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
