using Marathon.Core.Helpers;
using System.Threading.Tasks;
using Marathon.Core.Models.Runner;
using Marathon.Core.Services.Extensions;
using Marathon.Core.Services.Interfaces;

namespace Marathon.Core.Services
{
    public class RunnerService : IRunnerService
    {
        private readonly IRequestProvider _requestProvider;

        public RunnerService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public Task<uint> SignUpAsync(RunnerSignUpCredentials credentials)
        {
            var uri = UriHelper.CombineUri(GlobalSettings.Instance.RunnerSignUp);
            return _requestProvider.PostAsync<RunnerSignUpCredentials, uint>(uri, credentials, this.GetToken());
        }
    }
}
