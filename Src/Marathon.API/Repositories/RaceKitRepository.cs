using System.Linq;
using Marathon.Persistence;
using System.Collections.Generic;
using Marathon.API.Models.RaceKit;
using Marathon.API.Repositories.Interfaces;

namespace Marathon.API.Repositories
{
    internal class RaceKitRepository : IRaceKitRepository
    {
        private readonly MarathonDbContext _context;

        public RaceKitRepository(MarathonDbContext context)
        {
            _context = context;
        }

        // TODO: Make constraint if available
        public IEnumerable<RaceKit> GetAllRaceKits()
        {
            return _context.RaceKitOptions.Select(r => new RaceKit
            {
                Id = r.Id,
                Cost = r.Cost,
                Name = r.Name
            });
        }
    }
}
