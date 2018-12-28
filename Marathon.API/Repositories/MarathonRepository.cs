using System.Linq;
using Marathon.Persistence;
using System.Collections.Generic;
using Marathon.API.Repositories.Interfaces;

namespace Marathon.API.Repositories
{
    using EventType = Models.Marathon.EventType;

    internal class MarathonRepository : IMarathonRepository
    {
        private readonly MarathonDbContext _context;

        public MarathonRepository(MarathonDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EventType> GetAllEventTypes()
        {
            return _context.EventTypes.Select(e => new EventType
            {
                Id = e.Id,
                Name = e.Name
            });
        }
    }
}
