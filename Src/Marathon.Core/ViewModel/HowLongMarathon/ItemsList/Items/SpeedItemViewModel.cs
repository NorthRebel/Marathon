using System;
using Marathon.Core.ViewModel.HowLongMarathon.Models;

namespace Marathon.Core.ViewModel.HowLongMarathon.ItemsList.Items
{

    /// <summary>
    /// The view model for speed item of how long items list to compare
    /// </summary>
    public class SpeedItemViewModel : ItemToShow
    {
        #region Private Members

        private readonly IMarathonDistance _marathonDistance;

        #endregion

        #region Public Properties

        /// <summary>
        /// Time to elapse marathon distance
        /// </summary>
        public TimeSpan ElapseTime { get; set; }

        #endregion

        #region Constructor

        public SpeedItemViewModel(HowLongMarathonItemViewModel item, IMarathonDistance marathonDistance) : base(item)
        {
            _marathonDistance = marathonDistance;
            // Calculate time to elapse
            ElapseTime = TimeSpan.FromMinutes((_marathonDistance.Value / Value) * 60);
        }

        #endregion

        public override string ToString()
        {
            // TODO: It's temporary dummy solution, will change this later
            return $"Максимальная скорость {Name} равна {Value}км/ч. Это займет {ElapseTime:hh\\:mm\\:ss} чтобы завершить {_marathonDistance.Value}km марафон";
        }
    }
}
