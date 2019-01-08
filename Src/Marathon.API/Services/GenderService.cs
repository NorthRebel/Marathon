using AutoMapper;
using Marathon.API.Models;
using Marathon.Persistence;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Marathon.API.Services
{
    public class GenderService : IGenderService
    {
        private readonly MarathonDbContext _context;
        private readonly IMapper _mapper;

        public GenderService(MarathonDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Gender>> GetAllAsync()
        {
            return await _mapper.ProjectTo<Gender>(_context.Genders).ToArrayAsync();
        }
    }
}
