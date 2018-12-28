using System.Threading.Tasks;
using System.Collections.Generic;
using Marathon.Core.Models.Other;

namespace Marathon.Core.Services.Interfaces
{
    public interface IGenderService : IService
    {
        Task<IEnumerable<Gender>> GetAllAsync();
    }
}
