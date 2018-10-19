using System;
using System.Collections.Generic;
using System.Linq;
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
using Marathon.Core.IoC;

namespace Marathon.Desktop.Controls
{
    /// <summary>
    /// Логика взаимодействия для TitleBarControl.xaml
    /// </summary>
    public partial class TitleBarControl : UserControl
    {
        public TitleBarControl()
        {
            InitializeComponent();

            // Set data context to Title Bar view model
            DataContext = IoC.TitleBar;
        }
    }
}
