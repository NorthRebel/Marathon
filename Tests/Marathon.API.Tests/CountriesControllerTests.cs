using Xunit;
using System.Net;
using Marathon.API.Models;
using System.Threading.Tasks;
using Marathon.API.Tests.Client;
using Marathon.API.Tests.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Marathon.API.Tests.Client.RequestProvider;

namespace Marathon.API.Tests
{
    public class CountriesControllerTests
    {
        private readonly IRequestProvider _requestProvider;

        public CountriesControllerTests()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<StubStartup>());
            
            _requestProvider = new RequestProvider(server.CreateClient());
        }

        [Fact]
        public async Task ShouldReturnAllCountries()
        {
            ApiResponse<Country> response = await _requestProvider.GetAsync<Country>(Endpoints.AllCountries);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
