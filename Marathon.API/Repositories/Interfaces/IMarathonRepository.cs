using System.Collections.Generic;
using Marathon.API.Models.Marathon;

namespace Marathon.API.Repositories.Interfaces
{
    public interface IMarathonRepository
    {
        /// <summary>
        /// Gets all types of marathon events
        /// </summary>
        IEnumerable<EventType> GetAllEventTypes();
    }
}
