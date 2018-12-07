using System.Linq;
using Marathon.Persistence;
using Marathon.API.Exceptions;
using Marathon.Domain.Entities;
using Marathon.API.Repositories.Interfaces;

namespace Marathon.API.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly MarathonDbContext _context;

        public UserRepository(MarathonDbContext context)
        {
            _context = context;
        }

        public User SignIn(string email, string password)
        {
            User user = _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);

            if (user == null)
                throw new InvalidUserCredentialsException();

            return user;
        }

        public User SignUp(string email, string password, string firstName, string lastName, char userTypeId)
        {
            User existedUser = _context.Users.SingleOrDefault(u => u.Email == email);

            if (existedUser != null)
                throw new UserAlreadyExistsException();

            var newUser = new User
            {
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                UserTypeId = userTypeId
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return newUser;
        }
    }
}
