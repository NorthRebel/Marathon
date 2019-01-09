using System;
using Marathon.Core.ViewModel.HowLongMarathon.Models;

namespace Marathon.Core.ViewModel.HowLongMarathon.ItemsList.Items
{
    /// <summary>
    /// The view model for distance item of how long items list to compare
    /// </summary>
    public class DistanceItemViewModel : ItemToShow
    {
        #region Private Members

        private readonly IMarathonDistance _marathonDistance;

        #endregion

        #region Public Properties

        /// <summary>
        /// Count to cover marathon distance by item length value
        /// </summary>
        public long ItemsCount { get; set; }

        #endregion

        #region Constructor

        public DistanceItemViewModel(HowLongMarathonItemViewModel item, IMarathonDistance marathonDistance) : base(item)
        {
            _marathonDistance = marathonDistance;

            // Convert kilometers to meters
            double meters = _marathonDistance.Value * 1000;

            // Calculate items count to cover marathon distance
            ItemsCount = (long) Math.Ceiling(meters / Value);
        }

        #endregion

        public override string ToString()
        {
            // TODO: It's temporary dummy solution, will change this later
            return $"Длина {Name} равна {Value}м. Это займет {ItemsCount} из них, чтобы покрыть расстояние в {_marathonDistance.Value}км марафона";
        }
    }
}
