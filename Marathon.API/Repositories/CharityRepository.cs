using System.Linq;
using Marathon.Persistence;
using System.Collections.Generic;
using Marathon.API.Models.Charity;
using Marathon.API.Repositories.Interfaces;

namespace Marathon.API.Repositories
{
    internal class CharityRepository : ICharityRepository
    {
        private readonly MarathonDbContext _context;

        public CharityRepository(MarathonDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Charity> GetAll()
        {
            return _context.Charities.Select(c => new Charity
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public AboutCharity GetInfoAboutCharity(int id)
        {
            var charity = _context.Charities.Single(c => c.Id == id);

            return new AboutCharity
            {
                Name = charity.Name,
                Description = charity.Description,
                Logo = charity.Logo
            };
        }
    }
}
