using System;
using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.PageCaption;
using Marathon.Core.ViewModel.HowLongMarathon.Models;
using Marathon.Core.ViewModel.HowLongMarathon.ItemsList;
using Marathon.Core.ViewModel.HowLongMarathon.ItemsList.Items;
using Marathon.Core.ViewModel.HowLongMarathon.ItemsList.Items.Models;

namespace Marathon.Core.ViewModel.HowLongMarathon
{
    /// <summary>
    /// The view model for a how long marathon page
    /// </summary>
    public class HowLongMarathonViewModel : PageViewModel
    {
        #region Private Members

        /// <inheritdoc cref="IMarathonDistance"/>
        private readonly IMarathonDistance _marathonDistance;

        /// <summary>
        /// Selected item to compare
        /// </summary>
        private HowLongMarathonItemViewModel _selectedItem;

        #endregion

        #region Public Properties

        /// <summary>
        /// Items to compare how long is marathon regard self
        /// </summary>
        public IEnumerable<HowLongMarathonItemsListViewModel> ItemsToCompare { get; set; }
        
        /// <inheritdoc cref="_selectedItem"/>
        public HowLongMarathonItemViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value == null || _marathonDistance == null)
                    return;

                switch (value.Type)
                {
                    case HowLongItemType.Speed:
                        _selectedItem = new SpeedItemViewModel(value, _marathonDistance);
                        break;
                    case HowLongItemType.Distance:
                        _selectedItem = new DistanceItemViewModel(value, _marathonDistance);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        #endregion

        #region Constructor

        public HowLongMarathonViewModel()
        {
            PageCaption = new PageCaptionViewModel
            {
                Caption = "Насколько долгий марафон?"
            };
        }

        #endregion
    }
}
