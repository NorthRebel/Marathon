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

        public CharityService(MarathonDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Charity>> GetAllAsync()
        {
            return await _context.Charities.ProjectTo<Charity>().ToArrayAsync();
        }

        public async Task<AboutCharity> AboutCharity(int id)
        {
            var charity = await _context.Charities.SingleOrDefaultAsync(ch => ch.Id == id);

            return Mapper.Map<AboutCharity>(charity);
        }
    }
}
