using System;
using System.Diagnostics;
using System.Globalization;
using Marathon.Core.Models;
using Marathon.Desktop.Pages;

namespace Marathon.Desktop.ValueConverters
{

    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            // Find the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Main:
                    return new MainPage();
                case ApplicationPage.CheckRunner:
                    return new CheckRunnerPage();
                case ApplicationPage.SignIn:
                    return new SignInPage();
                case ApplicationPage.SignUpRunner:
                    return new SignUpRunnerPage();
                case ApplicationPage.SignUpToMarathon:
                    return new SignUpToMarathonPage();
                case ApplicationPage.SponsorRunner:
                    return new SponsorRunnerPage();
                case ApplicationPage.SponsorshipConfirm:
                    return new SponsorshipConfirmPage();
                case ApplicationPage.SignUpRunnerConfirm:
                    return new SignUpRunnerConfirmPage();
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
