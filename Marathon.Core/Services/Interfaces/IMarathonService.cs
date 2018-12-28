using System.Collections.Generic;
using System.Threading.Tasks;
using Marathon.Core.Models.Marathon;

namespace Marathon.Core.Services.Interfaces
{
    public interface IMarathonService : IService
    {
        Task<IEnumerable<EventType>> GetEventTypes();
    }
}
