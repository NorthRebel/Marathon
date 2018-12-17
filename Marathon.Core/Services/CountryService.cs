using Marathon.Core.Helpers;
using System.Threading.Tasks;
using Marathon.Core.Models.Other;
using Marathon.Core.Services.Extensions;
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

        public Task<Countries> GetAllAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSettings.Instance.AllCountries);

            return _requestProvider.GetAsync<Countries>(this.GetToken());
        }
    }
}
