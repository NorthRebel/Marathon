using System.Reflection;

namespace Marathon.Core.ViewModel.HowLongMarathon.ItemsList.Items
{
    /// <summary>
    /// How long item to show in UI
    /// </summary>
    public class ItemToShow : HowLongMarathonItemViewModel
    {
        public ItemToShow(HowLongMarathonItemViewModel baseInstance)
        {
            // Initialize base fields
            foreach (PropertyInfo pi in typeof(HowLongMarathonItemViewModel).GetProperties())
                GetType().GetProperty(pi.Name)?.SetValue(this, pi.GetValue(baseInstance, null), null);
        }
    }
}
