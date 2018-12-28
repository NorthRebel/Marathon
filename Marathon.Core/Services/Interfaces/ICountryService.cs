using System.Threading.Tasks;
using System.Collections.Generic;
using Marathon.Core.Models.Other;

namespace Marathon.Core.Services.Interfaces
{
    public interface ICountryService : IService
    {
        Task<IEnumerable<Country>> GetAllAsync();
    }
}
