using System.Threading.Tasks;

namespace Marathon.Core.Services.Genders
{
    using Models.Other;

    public interface IGenderService : IService
    {
        Task<Genders> GetAllAsync();
    }
}
