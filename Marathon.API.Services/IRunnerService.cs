using System.Threading.Tasks;

namespace Marathon.API.Services
{
    public interface IRunnerService : IService
    {
        Task<int> SignUpAsync(RunnerSignUpCredentials credentials);

        Task<int> GetId(int userId);
    }
}
