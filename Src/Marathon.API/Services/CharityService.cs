using AutoMapper;
using Marathon.Persistence;
using System.Threading.Tasks;
using System.Collections.Generic;
using Marathon.API.Models.Charity;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Marathon.API.Services
{
    public class CharityService : ICharityService
    {
        private readonly MarathonDbContext _context;
        private readonly IMapper _mapper;

        public CharityService(MarathonDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Charity>> GetAllAsync()
        {
            return await _mapper.ProjectTo<Charity>(_context.Charities).ToArrayAsync();
        }

        public async Task<AboutCharity> AboutCharity(int id)
        {
            var charity = await _context.Charities.SingleOrDefaultAsync(ch => ch.Id == id);

            return _mapper.Map<AboutCharity>(charity);
        }
    }
}
