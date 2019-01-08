using System.Threading.Tasks;
using Marathon.API.Models.Runner;

namespace Marathon.API.Services
{
    public interface IRunnerService : IService
    {
        Task<int> SignUpAsync(RunnerSignUpCredentials credentials);

        Task<int> GetId(int userId);
    }
}
