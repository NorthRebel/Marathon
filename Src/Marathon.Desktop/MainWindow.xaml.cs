using Marathon.Desktop.ViewModel;

namespace Marathon.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new WindowViewModel(this);
        }
    }
}
