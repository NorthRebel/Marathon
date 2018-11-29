using System.Data;
using Marathon.Tests.DAL;
using Marathon.DAL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Marathon.Application.Tests.Infrastructure
{
    /// <summary>
    /// Fixture for unit tests implementation of <see cref="IUnitOfWorkFactory"/>
    /// </summary>
    public class FixtureUoWFactory : IUnitOfWorkFactory
    {
        private readonly DbContextFixture _contextFixture;

        /// <summary>
        /// Default constructor
        /// </summary>
        public FixtureUoWFactory(DbContextFixture contextFixture)
        {
            _contextFixture = contextFixture;
        }

        // TODO: Implement set transaction isolation level method for db context
        public IUnitOfWork Create(IsolationLevel isolationLevel)
        {
            return new UnitOfWork(_contextFixture.ServiceProvider.GetService<TestDatabaseContext>());
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(_contextFixture.ServiceProvider.GetService<TestDatabaseContext>());
        }
    }
}
