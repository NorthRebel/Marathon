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
        private readonly DbContextOptions<TestDatabaseContext> _options;

        public UnitOfWorkFactory(DbContextOptions<TestDatabaseContext> options)
        {
            _options = options;
        }

        // TODO: Implement set transaction isolation level method for db context
        public IUnitOfWork Create(IsolationLevel isolationLevel)
        {
            return new UnitOfWork(new TestDatabaseContext(_options));
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(new TestDatabaseContext(_options));
        }
    }
}
