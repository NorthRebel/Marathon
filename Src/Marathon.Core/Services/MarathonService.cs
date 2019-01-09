using Marathon.API.Services;
using Marathon.Core.Helpers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Marathon.API.Models.Marathon;
using Marathon.Core.Services.Extensions;
using Marathon.Core.Services.Interfaces;

namespace Marathon.Core.Services
{
    public class MarathonService : IMarathonService
    {
        private readonly IRequestProvider _requestProvider;

        public MarathonService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public Task<IEnumerable<EventType>> GetEventTypes()
        {
            var uri = UriHelper.CombineUri(GlobalSettings.Instance.EventTypes);

            return _requestProvider.GetAsync<IEnumerable<EventType>>(uri, this.GetToken());
        }

        public Task<int> SignUp(MarathonSignUp signUpCredentials)
        {
            var uri = UriHelper.CombineUri(GlobalSettings.Instance.SignUpToMarathon);

            return _requestProvider.PostAsync<MarathonSignUp, int>(uri, signUpCredentials, this.GetToken());
        }

        public Task<StartupDate> GetStartupDate()
        {
            var uri = UriHelper.CombineUri(GlobalSettings.Instance.StartupDate);

            return _requestProvider.GetAsync<StartupDate>(uri);
        }
    }
}
