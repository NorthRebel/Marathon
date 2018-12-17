using System.Threading.Tasks;
using Marathon.Core.Models.Other;

namespace Marathon.Core.Services.Interfaces
{
    public interface ICountryService : IService
    {
        Task<Countries> GetAllAsync();
    }
}
