using AutoMapper;
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
        private readonly IMapper _mapper;

        public CountryService(MarathonDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _mapper.ProjectTo<Country>(_context.Charities).ToArrayAsync();
        }
    }
}
