using System.Linq;
using Marathon.API.Models;
using Marathon.Persistence;
using System.Collections.Generic;
using Marathon.API.Repositories.Interfaces;

namespace Marathon.API.Repositories
{
    internal class GenderRepository : IGenderRepository
    {
        private readonly MarathonDbContext _context;

        public GenderRepository(MarathonDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Gender> GetAll()
        {
            return _context.Genders.Select(g => new Gender
            {
                Id = g.Id,
                Name = g.Name
            });
        }
    }
}
