using System.Data;
using Marathon.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Marathon.Tests.DAL.Infrastructure
{
    /// <summary>
    /// Example implementation of <see cref="IUnitOfWorkFactory"/>
    /// </summary>
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly string _databaseName;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="databaseName">Name of in-memory database instance</param>
        public UnitOfWorkFactory(string databaseName)
        {
            _databaseName = databaseName;
        }

        // TODO: Implement set transaction isolation level method for db context
        public IUnitOfWork Create(IsolationLevel isolationLevel)
        {
            var context = new TestDatabaseContext(InitializeDatabase());
            context.Database.EnsureCreated();

            return new UnitOfWork(context);
        }

        public IUnitOfWork Create()
        {
            var context = new TestDatabaseContext(InitializeDatabase());
            context.Database.EnsureCreated();

            return new UnitOfWork(context);
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
                .UseInMemoryDatabase(databaseName: _databaseName)
                .Options;
        }

        public static void Destroy(IUnitOfWork unitOfWork)
        {
            var dbContext = unitOfWork as DbContext;
            dbContext?.Database.EnsureDeleted();

            unitOfWork.Dispose();
        }
    }
}
