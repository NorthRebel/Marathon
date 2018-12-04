using System;
using Autofac;
using System.Threading;
using Marathon.Persistence;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;
using Marathon.DAL.Initializer;
using Marathon.Tests.DAL.Extensions;
using Marathon.Tests.DAL.Infrastructure.IoC;
using Microsoft.EntityFrameworkCore;

namespace Marathon.Tests.DAL.Infrastructure
{
    /// <summary>
    /// Shared context among all the tests in the unit test module
    /// </summary>
    public class UnitOfWorkFixture : BootStrapper, IDisposable
    {
        private Guid _databaseId;

        public IContainer Container { get; }

        public IUnitOfWork Context => Container.Resolve<IUnitOfWork>();

        public IUnitOfWorkFactory ContextFactory => Container.Resolve<IUnitOfWorkFactory>();

        public UnitOfWorkFixture()
        {
            _databaseId = Guid.NewGuid();
            Container = Build();
        }

        private async Task InitializeContext(IUnitOfWork uow)
        {
            var initializer = new UnitOfWorkInitializer(uow, CancellationToken.None);
            await initializer.Seed();
        }

        protected override IUnitOfWorkFactory ConfigureUoWFactory()
        {
            return new UnitOfWorkFactory(GetDbContext(true));
        }

        protected override IUnitOfWork ConfigureUoW()
        {
            IUnitOfWork uow = ContextFactory.Create();

            // Non-async, else tests will be fail 
#pragma warning disable 4014
            InitializeContext(uow);
#pragma warning restore 4014

            return uow;
        }

        private DbContext GetDbContext(bool useSqlLite = false)
        {
            var context = new MarathonDbContext(ConfigureDbContext<MarathonDbContext>(useSqlLite));

            // SQLite needs to open connection to the DB.
            if (useSqlLite)
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();
            }

            return context;
        }

        private DbContextOptions<TContext> ConfigureDbContext<TContext>(bool useSqlLite) where TContext : DbContext
        {
            var builder = new DbContextOptionsBuilder<TContext>();

            if (useSqlLite)
                builder.UseSqlite("DataSource=:memory:");
            else
                builder.UseInMemoryDatabase(_databaseId.ToString());

            return builder.Options;
        }

        public void Dispose()
        {
            var dbContext = ExtractDbContextFromUoW();

            {
                dbContext.Database.CloseConnection();
                dbContext.Database.EnsureDeleted();
                dbContext.Dispose();
            }

            Context?.Dispose();
        }

        private DbContext ExtractDbContextFromUoW()
        {
            return Context.GetFieldValue<DbContext>("_dbContext");
        }
    }
}
