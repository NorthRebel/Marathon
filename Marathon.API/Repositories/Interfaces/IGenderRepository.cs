using System.Collections.Generic;

namespace Marathon.API.Repositories.Interfaces
{
    public interface IGenderRepository
    {
        IEnumerable<string> GetAllNames();
        char GetIdByName(string name);
    }
}
