using System.Collections.Generic;
using System.Threading.Tasks;
using Marathon.Core.Models.RaceKit;

namespace Marathon.Core.Services.Interfaces
{
    public interface IRaceKitService : IService
    {
        Task<IEnumerable<RaceKit>> GetAll();
    }
}
