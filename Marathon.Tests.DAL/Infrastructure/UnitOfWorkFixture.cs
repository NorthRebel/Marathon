using System;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.Initializer;
using Marathon.Persistence;
using Marathon.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Marathon.Tests.DAL.Infrastructure
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
            ContextFactory = new UnitOfWorkFactory(GetDbContext());
            Context = ContextFactory.Create();

            Task.Run(() => InitializeContext(Context));
        }

        private async Task InitializeContext(IUnitOfWork uow)
        {
            var initializer = new UnitOfWorkInitializer(uow, CancellationToken.None);
            await initializer.Seed();
        }

        private DbContext GetDbContext(bool useSqlLite = false) 
        {
            var context = new MarathonDbContext(ConfigureDbContext<MarathonDbContext>(useSqlLite));

            // SQLite needs to open connection to the DB.
            if (useSqlLite)
                context.Database.OpenConnection();

            return context;
        }

        private DbContextOptions<TContext> ConfigureDbContext<TContext>(bool useSqlLite) where TContext : DbContext
        {
            var builder = new DbContextOptionsBuilder<TContext>();

            if (useSqlLite)
                builder.UseSqlite("DataSource=:memory:", x => { });
            else
                builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            return builder.Options;
        }

        public void Dispose()
        {
            var dbContext = Context as DbContext;
            dbContext?.Database.EnsureDeleted();

            Context.Dispose();
        }
    }
}
