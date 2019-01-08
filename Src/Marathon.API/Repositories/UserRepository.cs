using System.Linq;
using Marathon.Persistence;
using Marathon.API.Exceptions;
using Marathon.API.Models.User;
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

        public User SignIn(UserSignInCredentials credentials)
        {
            User user = _context.Users.SingleOrDefault(u => u.Email == credentials.Email && u.Password == credentials.Password);

            if (user == null)
                throw new InvalidUserCredentialsException();

            return user;
        }

        #region SignUp
        
        public User SignUp(UserSignUpCredentials credentials)
        {
            if (IsUserExists(credentials.Email))
                throw new UserAlreadyExistsException();

            var newUser = CreateNewUser(credentials);

            SaveUser(newUser);

            return newUser;
        }

        private void SaveUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        private User CreateNewUser(UserSignUpCredentials credentials)
        {
            return new User
            {
                Email = credentials.Email,
                Password = credentials.Password,
                FirstName = credentials.FirstName,
                LastName = credentials.LastName,
                UserTypeId = credentials.UserTypeId
            };
        }

        private bool IsUserExists(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email) != null;
        }

        #endregion
    }
}
