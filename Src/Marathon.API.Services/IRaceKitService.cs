using System.Collections.Generic;
using System.Threading.Tasks;
using Marathon.API.Models.RaceKit;

namespace Marathon.API.Services
{
    public interface IRaceKitService : IService
    {
        Task<IEnumerable<RaceKit>> GetAll();
    }
}
