using System.Data;
using Marathon.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Marathon.DAL.Tests.Infrastructure
{
    /// <summary>
    /// Example implementation of <see cref="IUnitOfWorkFactory"/>
    /// </summary>
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        // TODO: Implement set transaction isolation level method for db context
        public IUnitOfWork Create(IsolationLevel isolationLevel)
        {
            return new UnitOfWork(new TestDatabaseContext(InitializeDatabase()));
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(new TestDatabaseContext(InitializeDatabase()));
        }

        /// <summary>
        /// Default in-memory database initializer for all instances
        /// </summary>
        private DbContextOptions<TestDatabaseContext> InitializeDatabase()
        {
            // The database name allows the scope of the in-memory database
            // to be controlled independently of the context. The in-memory database is shared
            // anywhere the same name is used.
            return new DbContextOptionsBuilder<TestDatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
        }
    }
}
