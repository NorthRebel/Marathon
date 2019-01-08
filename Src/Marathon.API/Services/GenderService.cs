using Marathon.API.Models;
using Marathon.Persistence;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Marathon.API.Services
{
    public class GenderService : IGenderService
    {
        private readonly MarathonDbContext _context;

        public GenderService(MarathonDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gender>> GetAllAsync()
        {
            return await _context.Genders.ProjectTo<Gender>().ToArrayAsync();
        }
    }
}
