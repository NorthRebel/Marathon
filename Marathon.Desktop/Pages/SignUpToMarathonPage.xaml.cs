using System.Windows.Controls;
using Marathon.Core.ViewModel.SignUpToMarathon;

namespace Marathon.Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignUpToMarathonPage.xaml
    /// </summary>
    public partial class SignUpToMarathonPage : BasePage<SignUpToMarathonViewModel>
    {
        public SignUpToMarathonPage()
        {
            InitializeComponent();

            BindAboutSelectedCharityCommandParamether();
        }

        /// <summary>
        /// This method is fix XAML issue : 
        /// In custom user controls i can't defile "Name" property for communicate Combobox.SelectedItem property to button command parameter
        /// </summary>
        private void BindAboutSelectedCharityCommandParamether()
        {
            var infoAboutCharityButton = (Button)FindName("InfoAboutCharityButton");

            var charityList = (ComboBox)FindName("CharityList");

            infoAboutCharityButton.CommandParameter = charityList.SelectedItem;
        }
    }
}
