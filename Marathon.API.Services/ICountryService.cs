using System.Collections.Generic;
using System.Threading.Tasks;
using Marathon.API.Models;

namespace Marathon.API.Services
{
    public interface ICountryService : IService
    {
        Task<IEnumerable<Country>> GetAllAsync();
    }
}
