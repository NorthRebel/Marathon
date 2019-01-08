using System.Collections.Generic;
using System.Threading.Tasks;
using Marathon.API.Models.Charity;

namespace Marathon.API.Services
{
    public interface ICharityService : IService
    {
        Task<IEnumerable<Charity>> GetAllAsync();

        Task<AboutCharity> AboutCharity(int id);
    }
}
