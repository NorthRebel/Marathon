using System.Linq;
using Marathon.Persistence;
using System.Collections.Generic;
using Marathon.API.Models;
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

        public IEnumerable<Country> GetAll()
        {
            return _context.Countries.Select(c => new Country
            {
                Id = c.Id,
                Name = c.Name
            });
        }
    }
}
