using Marathon.Core.Helpers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Marathon.Core.Models.Other;
using Marathon.Core.Services.Interfaces;

namespace Marathon.Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly IRequestProvider _requestProvider;

        public CountryService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public Task<IEnumerable<Country>> GetAllAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSettings.Instance.AllCountries);

            return _requestProvider.GetAsync<IEnumerable<Country>>(uri);
        }
    }
}
