using Marathon.API.Models.User;
using Marathon.Domain.Entities;

namespace Marathon.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User SignIn(UserSignInCredentials credentials);
        User SignUp(UserSignUpCredentials credentials);
    }
}
