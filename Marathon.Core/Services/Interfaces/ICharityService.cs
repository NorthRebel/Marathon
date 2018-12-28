using System.Threading.Tasks;
using System.Collections.Generic;
using Marathon.Core.Models.Charity;

namespace Marathon.Core.Services.Interfaces
{
    public interface ICharityService : IService
    {
        Task<IEnumerable<Charity>> GetAllAsync();
    }
}
