using Marathon.Core.Helpers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Marathon.Core.Models.Other;
using Marathon.Core.Services.Interfaces;

namespace Marathon.Core.Services
{
    public class GenderService : IGenderService
    {
        private readonly IRequestProvider _requestProvider;

        public GenderService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public Task<IEnumerable<Gender>> GetAllAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSettings.Instance.AllGenders);

            return _requestProvider.GetAsync<IEnumerable<Gender>>(uri);
        }
    }
}
