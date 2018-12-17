using Marathon.Core.Helpers;
using System.Threading.Tasks;
using Marathon.Core.Models.Other;
using Marathon.Core.Services.Extensions;
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

        public Task<Genders> GetAllAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSettings.Instance.AllGenders);

            return _requestProvider.GetAsync<Genders>(this.GetToken());
        }
    }
}
