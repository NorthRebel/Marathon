using Marathon.API.Models;
using Marathon.Persistence;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Marathon.API.Services
{
    public class CountryService : ICountryService
    {
        private readonly MarathonDbContext _context;

        public CountryService(MarathonDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _context.Countries.ProjectTo<Country>().ToArrayAsync();
        }
    }
}
