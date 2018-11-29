using System;
using Marathon.Tests.DAL;
using Marathon.DAL.UnitOfWork;

namespace Marathon.Application.Tests.Infrastructure
{
    /// <summary>
    /// Shared context among all the tests in the unit test module
    /// </summary>
    public class UnitOfWorkFixture : IDisposable
    {
        public IUnitOfWork Context { get; }

        public IUnitOfWorkFactory ContextFactory { get; }

        public UnitOfWorkFixture()
        {
            var databaseName = Guid.NewGuid().ToString();

            ContextFactory = new UnitOfWorkFactory(databaseName);
            Context = ContextFactory.Create();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
