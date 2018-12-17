using System.Threading.Tasks;
using Marathon.Core.Models.Runner;

namespace Marathon.Core.Services.Runner
{
    public interface IRunnerService : IService
    {
        Task<uint> SignUpAsync(RunnerSignUpCredentials credentials);
    }
}
