using System;
using System.Globalization;
using System.Windows;
using Marathon.Core.ViewModel.ManageUser.Models;

namespace Marathon.Desktop.ValueConverters
{
    /// <summary>
    /// A converter that takes in a <see cref="UserManagementType"/> and returns a <see cref="Visibility"/>
    /// </summary>
    public class UserManagementTypeToVisibilityConverter : BaseValueConverter<UserManagementTypeToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is UserManagementType managementType))
                throw new InvalidOperationException($"The target must be a {nameof(UserManagementType)}");

            Visibility result;

            switch (managementType)
            {
                case UserManagementType.Add:
                    result = Visibility.Collapsed;
                    break;
                case UserManagementType.Edit:
                    result = Visibility.Visible;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(managementType), managementType, null);
            }

            if (parameter == null)
                return result;

            switch (result)
            {
                case Visibility.Visible:
                    return Visibility.Collapsed;
                case Visibility.Collapsed:
                    return Visibility.Visible;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
