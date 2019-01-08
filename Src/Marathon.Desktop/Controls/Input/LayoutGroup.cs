using System.Windows.Controls;

namespace Marathon.Desktop.Controls.Input
{
    public class LayoutGroup : StackPanel
    {
        public LayoutGroup()
        {
            Grid.SetIsSharedSizeScope(this, true);
        }
    }
}
