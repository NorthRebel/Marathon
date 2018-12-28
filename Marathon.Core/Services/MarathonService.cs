using Marathon.Core.Helpers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Marathon.Core.Models.Marathon;
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

            return _requestProvider.GetAsync<IEnumerable<EventType>>(uri);
        }
    }
}
