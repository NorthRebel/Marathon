using System.Collections.Generic;
using Marathon.API.Models.RaceKit;

namespace Marathon.API.Repositories.Interfaces
{
    public interface IRaceKitRepository
    {
        /// <summary>
        /// Gets all available race kits for runner which signs up to the marathon
        /// </summary>
        IEnumerable<RaceKit> GetAllRaceKits();
    }
}
