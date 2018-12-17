using Marathon.API.Models.Runner;

namespace Marathon.API.Repositories.Interfaces
{
    public interface IRunnerRepository
    {
        uint SignUp(RunnerSignUpCredentials credentials);
    }
}
