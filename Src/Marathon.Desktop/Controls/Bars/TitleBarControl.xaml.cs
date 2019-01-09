using System.Windows.Controls;
using Kernel = Marathon.Core.IoC.IoC;

namespace Marathon.Desktop.Controls.Bars
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
            DataContext = Kernel.TitleBar;
        }
    }
}
