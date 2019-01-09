using AutoMapper;
using Marathon.Persistence;
using System.Threading.Tasks;
using System.Collections.Generic;
using Marathon.API.Models.RaceKit;
using Microsoft.EntityFrameworkCore;

namespace Marathon.API.Services
{
    public class RaceKitService : IRaceKitService
    {
        private readonly MarathonDbContext _context;
        private readonly IMapper _mapper;

        public RaceKitService(MarathonDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RaceKit>> GetAll()
        {
            return await _mapper.ProjectTo<RaceKit>(_context.RaceKitOptions).ToArrayAsync();
        }
    }
}
