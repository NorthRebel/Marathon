using System.Linq;
using Marathon.Persistence;
using System.Collections.Generic;
using Marathon.API.Repositories.Interfaces;

namespace Marathon.API.Repositories
{
    internal class CountryRepository : ICountryRepository
    {
        private readonly MarathonDbContext _context;

        public CountryRepository(MarathonDbContext context)
        {
            _context = context;
        }

        public IEnumerable<string> GetAllNames()
        {
            return _context.Countries.Select(c => c.Name);
        }

        public string GetIdByName(string name)
        {
            return _context.Countries.Single(c => c.Name == name).Id;
        }
    }
}
