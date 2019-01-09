using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Marathon.API.Tests.Server
{
    public class StubStartup : Startup
    {
        public StubStartup() : base(null)
        {
        }

        protected override void ConfigureDatabaseContext(IServiceCollection services)
        {
            // Don't use context in tests
        }

        protected override void BindCommonServices(IServiceCollection services)
        {
            // Don't use original services configuration
        }
    }
}
