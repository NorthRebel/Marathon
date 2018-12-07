using Marathon.Domain.Entities;

namespace Marathon.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User SignIn(string email, string password);
        User SignUp(string email, string password, string firstName, string lastName, char userTypeId);
    }
}
