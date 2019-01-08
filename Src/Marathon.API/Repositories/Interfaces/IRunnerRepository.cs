using Marathon.API.Models.Runner;

namespace Marathon.API.Repositories.Interfaces
{
    public interface IRunnerRepository
    {
        int SignUp(RunnerSignUpCredentials credentials);

        int GetId(int userId);
    }
}
