using Marathon.Core.Helpers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Marathon.Core.Models.RaceKit;
using Marathon.Core.Services.Interfaces;

namespace Marathon.Core.Services
{
    public class RaceKitService : IRaceKitService
    {
        private readonly IRequestProvider _requestProvider;

        public RaceKitService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public Task<IEnumerable<RaceKit>> GetAll()
        {
            var uri = UriHelper.CombineUri(GlobalSettings.Instance.AllRaceKits);

            return _requestProvider.GetAsync<IEnumerable<RaceKit>>(uri);
        }
    }
}
