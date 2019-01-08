using Marathon.Persistence;
using System.Threading.Tasks;
using System.Collections.Generic;
using Marathon.API.Models.RaceKit;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Marathon.API.Services
{
    public class RaceKitService : IRaceKitService
    {
        private readonly MarathonDbContext _context;

        public RaceKitService(MarathonDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RaceKit>> GetAll()
        {
            return await _context.RaceKitOptions.ProjectTo<RaceKit>().ToArrayAsync();
        }
    }
}
