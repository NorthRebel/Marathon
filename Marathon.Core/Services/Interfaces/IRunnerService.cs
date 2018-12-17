using System.Threading.Tasks;
using Marathon.Core.Models.Runner;

namespace Marathon.Core.Services.Interfaces
{
    public interface IRunnerService : IService
    {
        Task<uint> SignUpAsync(RunnerSignUpCredentials credentials);
    }
}
