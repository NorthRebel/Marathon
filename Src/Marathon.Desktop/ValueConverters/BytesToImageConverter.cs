using System;
using System.Globalization;
using System.IO;
using System.Windows.Media.Imaging;

namespace Marathon.Desktop.ValueConverters
{
    /// <summary>
    /// Converts byte array to <see cref="BitmapImage"/>
    /// </summary>
    public class BytesToImageConverter : BaseValueConverter<BytesToImageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is byte[] bytes))
                return null;

            if (bytes.Length == default(int))
                return null;

            var image = new BitmapImage();

            using (var mem = new MemoryStream(bytes))
            {
                mem.Position = 0;

                image.BeginInit();

                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;

                image.EndInit();
            }

            image.Freeze();
            return image;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
