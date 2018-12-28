using System.Collections.Generic;
using Marathon.API.Models.Charity;

namespace Marathon.API.Repositories.Interfaces
{
    public interface ICharityRepository
    {
        IEnumerable<Charity> GetAll();
    }
}
