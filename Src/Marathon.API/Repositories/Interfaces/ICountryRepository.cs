using Marathon.API.Models;
using System.Collections.Generic;

namespace Marathon.API.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAll();
    }
}
