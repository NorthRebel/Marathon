using Marathon.API.Services;
using Marathon.Core.Helpers;
using System.Threading.Tasks;
using Marathon.API.Models.Runner;
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

        public Task<int> SignUpAsync(RunnerSignUpCredentials credentials)
        {
            var uri = UriHelper.CombineUri(GlobalSettings.Instance.RunnerSignUp);
            return _requestProvider.PostAsync<RunnerSignUpCredentials, int>(uri, credentials, this.GetToken());
        }

        public Task<int> GetId(int userId)
        {
            var uri = UriHelper.CombineUri(GlobalSettings.Instance.GetRunnerIdRoute(userId));
            return _requestProvider.GetAsync<int>(uri, this.GetToken());
        }
    }
}
