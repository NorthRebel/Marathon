using System.Collections.Generic;

namespace Marathon.API.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<string> GetAllNames();
        string GetIdByName(string name);
    }
}
