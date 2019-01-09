using System;
using System.Windows.Threading;
using Marathon.Core.ViewModel.BottomBar;

namespace Marathon.Desktop.Controls.Bars
{
    /// <summary>
    /// Логика взаимодействия для BottomBarControl.xaml
    /// </summary>
    public partial class BottomBarControl : BaseControl<BottomBarViewModel>
    {
        public BottomBarControl()
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

        // TODO: Make stop timer if view model props hasn't values
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!(DataContext is BottomBarViewModel viewModel))
                return;

            viewModel.CalculateRemainingTime();
        }
    }
}
