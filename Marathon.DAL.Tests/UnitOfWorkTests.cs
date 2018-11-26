using System.Collections.Generic;
using System.Linq;
using Xunit;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.Repositories;
using Marathon.DAL.UnitOfWork;
using Marathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Marathon.DAL.Tests.Infrastructure;

namespace Marathon.DAL.Tests
{
    /// <summary>
    /// Unit test module for in-memory EF Core example implementation of <see cref="IUnitOfWork"/>
    /// </summary>
    public class UnitOfWorkTests
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public UnitOfWorkTests()
        {
            _uowFactory=  new UnitOfWorkFactory(InitializeDatabase());
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

        [Fact]
        public async Task CheckInMemoryProvider()
        {
            // Arrange-act

            const string userEmail = "a.beaulieu@hotmail.com";

            using (IUnitOfWork context = _uowFactory.Create())
            {
                var user = new User
                {
                    Email = userEmail,
                    Password = "qWOvG6TJ",
                    FirstName = "ANTON",
                    LastName = "BEAULIEU",
                    UserTypeId = 3
                };

                context.Users.Add(user);
                await context.CommitAsync(CancellationToken.None);
            }

            // Act-assert
            // New context with the data as the database name is the same
            using (IUnitOfWork context = _uowFactory.Create())
            {
                IEnumerable<User> users = await context.Users.GetAllAsync();
                Assert.Single(users);

                var createdUser = context.Users.GetSingleAsync(u => u.Email == userEmail);
                Assert.NotNull(createdUser);
            }
        }
    }
}
