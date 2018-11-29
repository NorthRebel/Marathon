using System;
using Marathon.Tests.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Marathon.Application.Tests.Infrastructure
{
    public class DbContextFixture
    {
        private readonly string _databaseName;

        public ServiceProvider ServiceProvider { get; }

        public DbContextFixture()
        {
            _databaseName = Guid.NewGuid().ToString();

            var serviceCollection = new ServiceCollection();
            serviceCollection
                .AddDbContext<TestDatabaseContext>(options => options.UseInMemoryDatabase(_databaseName), ServiceLifetime.Transient);

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }

    [CollectionDefinition("Database collection")]
    public class DatabaseCollection : ICollectionFixture<DbContextFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
