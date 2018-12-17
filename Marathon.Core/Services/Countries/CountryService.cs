using Marathon.Core.Helpers;
using System.Threading.Tasks;
using Marathon.Core.Services.Extensions;
using Marathon.Core.Services.RequestProvider;

namespace Marathon.Core.Services.Countries
{
    using Models.Other;

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
