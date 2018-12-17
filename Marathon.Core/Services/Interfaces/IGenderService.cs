using System.Threading.Tasks;
using Marathon.Core.Models.Other;

namespace Marathon.Core.Services.Interfaces
{
    public interface IGenderService : IService
    {
        Task<Genders> GetAllAsync();
    }
}
