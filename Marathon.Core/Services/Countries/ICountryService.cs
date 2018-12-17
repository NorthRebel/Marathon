using System.Threading.Tasks;

namespace Marathon.Core.Services.Countries
{
    using Models.Other;

    public interface ICountryService : IService
    {
        Task<Countries> GetAllAsync();
    }
}
