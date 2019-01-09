using System;
using System.Windows.Threading;
using Marathon.Core.ViewModel.MainTitleBar;

namespace Marathon.Desktop.Controls.Bars
{
    /// <summary>
    /// Логика взаимодействия для MainTitleBarControl.xaml
    /// </summary>
    public partial class MainTitleBarControl : BaseControl<MainTitleBarViewModel>
    {
        public MainTitleBarControl()
        {
            InitializeComponent();

            var dispatcherTimer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 1, 0)
            };

            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();

            dispatcherTimer_Tick(dispatcherTimer, EventArgs.Empty);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!(DataContext is MainTitleBarViewModel viewModel))
                return;

            viewModel.GetCurrentDate();
        }
    }
}
