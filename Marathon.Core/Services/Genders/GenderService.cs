using Marathon.Core.Helpers;
using System.Threading.Tasks;
using Marathon.Core.Services.Extensions;
using Marathon.Core.Services.RequestProvider;

namespace Marathon.Core.Services.Genders
{
    using Models.Other;

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
