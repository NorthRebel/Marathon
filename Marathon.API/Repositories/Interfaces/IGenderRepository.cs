using System.Collections.Generic;
using Marathon.API.Models;

namespace Marathon.API.Repositories.Interfaces
{
    public interface IGenderRepository
    {
        IEnumerable<Gender> GetAll();
    }
}
