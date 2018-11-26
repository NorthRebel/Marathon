using Xunit;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;
using Marathon.Domain.Entities;
using Marathon.DAL.Repositories;
using System.Collections.Generic;
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
            _uowFactory=  new UnitOfWorkFactory();
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
