using System.Linq;
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

        public IEnumerable<string> GetAllNames()
        {
            return _context.Genders.Select(g => g.Name);
        }

        public char GetIdByName(string name)
        {
            return _context.Genders.Single(g => g.Name == name).Id;
        }
    }
}
