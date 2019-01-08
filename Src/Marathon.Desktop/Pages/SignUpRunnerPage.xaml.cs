using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Marathon.Core.ViewModel;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.SignUpRunner;

namespace Marathon.Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignUpRunnerPage.xaml
    /// </summary>
    public partial class SignUpRunnerPage : BasePage<SignUpRunnerViewModel>
    {
        public SignUpRunnerPage()
        {
            InitializeComponent();
        }
    }
}
