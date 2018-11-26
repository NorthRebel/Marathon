using System;
using Xunit;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;
using Marathon.Domain.Entities;
using Marathon.DAL.Repositories;
using System.Collections.Generic;
using System.Diagnostics;
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
            _uowFactory = new UnitOfWorkFactory();
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

        ///<remarks>
        /// I didn't use using block because arises await-disposable problem 
        ///</remarks>
        [Fact]
        public async Task EntrySavedAfterAdd()
        {
            // Arrange
            IEnumerable<Event> events;
            IUnitOfWork context = _uowFactory.Create();

            // Act
            context.Events.Add(new Event());
            await context.CommitAsync(CancellationToken.None);
            events = await context.Events.GetAllAsync();

            // Assert
            Assert.True(events.Any());

            // Cleanup
            context.Dispose();
        }

        [Fact]
        public async Task EntryNotSaveIfContextNotCommit()
        {
            // Arrange
            IEnumerable<Volunteer> volunteers;
            IUnitOfWork context = _uowFactory.Create();

            // Act
            context.Volunteers.Add(new Volunteer());
            volunteers = await context.Volunteers.GetAllAsync();

            // Assert
            Assert.False(volunteers.Any());

            // Cleanup
            context.Dispose();
        }

        [Fact]
        public async Task EntryIsUpdatedAfterChangeProperty()
        {
            // Arrange
            User findByUpdated;
            const string emailBeforeUpdate = "testAdd@hotmail.com";
            const string emailAfterUpdate = "testUpdate@hotmail.com";

            // Act
            using (IUnitOfWork context = _uowFactory.Create())
            {
                context.Users.Add(new User { Email = emailBeforeUpdate });
                await context.CommitAsync(CancellationToken.None);

                User addedUser = await context.Users.GetSingleAsync(u => u.Email == emailBeforeUpdate);
                addedUser.Email = emailAfterUpdate;

                context.Users.Update(addedUser);
                await context.CommitAsync(CancellationToken.None);

                findByUpdated = await context.Users.GetSingleAsync(u => u.Email == emailAfterUpdate);
            }

            // Assert
            Assert.NotNull(findByUpdated);
            Assert.Equal(emailAfterUpdate, findByUpdated.Email);
        }

        [Fact]
        public async Task EntryNotExistsAfterDelete()
        {
            // Arrange
            const string lastName = "Jonson";
            Volunteer volunteer = new Volunteer { LastName = lastName };

            // Act
            using (IUnitOfWork context = _uowFactory.Create())
            {
                context.Volunteers.Add(volunteer);
                await context.CommitAsync(CancellationToken.None);

                context.Volunteers.Remove(volunteer);
                await context.CommitAsync(CancellationToken.None);

                volunteer = await context.Volunteers.GetSingleAsync(v => v.LastName == lastName);
            }

            // Assert
            Assert.Null(volunteer);
        }

        [Fact]
        public async Task ContextRestoreValuePropertiesAfterRollback()
        {
            // Arrange
            const string sponsorName = "Dylan Smith";
            Sponsorship sponsorship = new Sponsorship { Name = sponsorName };

            // Act
            using (IUnitOfWork context = _uowFactory.Create())
            {
                context.Sponsorships.Add(sponsorship);
                await context.CommitAsync(CancellationToken.None);

                sponsorship.Name = "Frank Martin";

                context.Rollback();
            }

            // Assert
            Assert.Equal(sponsorName, sponsorship.Name);
        }

        [Fact]
        public async Task ContextCachesLastReceivedResults()
        {
            // Arrange
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan beforeCache, afterCache;

            // Generate random list of entries
            IEnumerable<User> users = Enumerable.Range(1, 100).Select(u => new User());

            // Act
            using (IUnitOfWork context = _uowFactory.Create())
            {
                foreach (User user in users)
                    context.Users.Add(user);
                await context.CommitAsync(CancellationToken.None);

                stopwatch.Start();
                // Non async!
#pragma warning disable 4014
                context.Users.GetAllAsync();
#pragma warning restore 4014
                stopwatch.Stop();
                beforeCache = stopwatch.Elapsed;

                stopwatch.Reset();

                stopwatch.Start();
                // Non async!
#pragma warning disable 4014
                context.Users.GetAllAsync();
#pragma warning restore 4014
                stopwatch.Stop();
                afterCache = stopwatch.Elapsed;
            }

            Console.WriteLine($"Test name: {nameof(ContextCachesLastReceivedResults)}; Before cache: {beforeCache.Milliseconds} ms.");
            Console.WriteLine($"Test name: {nameof(ContextCachesLastReceivedResults)}; After cache: {afterCache.Milliseconds} ms.");

            // Assert
            Assert.True(afterCache < beforeCache);
        }
    }
}
