using Marathon.Core.Helpers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Marathon.Core.Models.Charity;
using Marathon.Core.Services.Interfaces;

namespace Marathon.Core.Services
{
    public class CharityService : ICharityService
    {
        private readonly IRequestProvider _requestProvider;

        public CharityService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public Task<IEnumerable<Charity>> GetAllAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSettings.Instance.AllCharities);

            return _requestProvider.GetAsync<IEnumerable<Charity>>(uri);
        }

        public Task<AboutCharity> AboutCharity(int id)
        {
            var uri = UriHelper.CombineUri(GlobalSettings.Instance.GetAboutCharityRoute(id));

            return _requestProvider.GetAsync<AboutCharity>(uri);
        }
    }
}
