using AutoMapper;
using Marathon.Persistence;
using System.Threading.Tasks;
using Marathon.API.Exceptions;
using Marathon.Domain.Entities;
using Marathon.API.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Marathon.API.Services
{
    public class UserService : IUserService
    {
        private readonly MarathonDbContext _context;

        public UserService(MarathonDbContext context)
        {
            _context = context;
        }

        public async Task<UserInfo> SignInAsync(UserSignInCredentials credentials)
        {
            UserInfo result = null;

            await _context.Users.SingleOrDefaultAsync(u => u.Email == credentials.Email && u.Password == credentials.Password)
                .ContinueWith(u =>
                {
                    if(u.Result == null)
                        throw new InvalidUserCredentialsException();

                    result = Mapper.Map<UserInfo>(u.Result);
                });

            return result;
        }

        public async Task<UserInfo> SignUpAsync(UserSignUpCredentials credentials)
        {
            if (IsUserExists(credentials.Email).Result)
                throw new UserAlreadyExistsException();

            var newUser = CreateNewUser(credentials);

            UserInfo result = null;

            await SaveUser(newUser)
                .ContinueWith(u => result = Mapper.Map<UserInfo>(newUser));

            return result;
        }

        #region SignUp

        private Task SaveUser(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChangesAsync();
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

        private async Task<bool> IsUserExists(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email) != null;
        }

        #endregion
    }
}
