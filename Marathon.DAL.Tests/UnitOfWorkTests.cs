using Xunit;
using System;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;
using Marathon.Domain.Entities;
using Marathon.DAL.Repositories;
using System.Collections.Generic;
using Marathon.Tests.DAL.Infrastructure;
using UserType = Marathon.Domain.Enumerations.UserType;

namespace Marathon.DAL.Tests
{
    /// <summary>
    /// Unit test module for in-memory EF Core example implementation of <see cref="IUnitOfWork"/>
    /// </summary>
    public class UnitOfWorkTests : IClassFixture<UnitOfWorkFixture>
    {
        private readonly IUnitOfWork _context;

        public UnitOfWorkTests(UnitOfWorkFixture unitOfWorkFixture)
        {
            _context = unitOfWorkFixture.Context;
        }

        [Fact]
        public async Task CheckInMemoryProvider()
        {
            // Arrange-act

            const string userEmail = "a.beaulieu@hotmail.com";

            var user = new User
            {
                Email = userEmail,
                Password = "qWOvG6TJ",
                FirstName = "ANTON",
                LastName = "BEAULIEU",
                UserTypeId = UserType.Runner.Id
            };

            _context.Users.Add(user);
            await _context.CommitAsync(CancellationToken.None);

            // Act-assert
            IEnumerable<User> users = await _context.Users.GetAllAsync();
            Assert.Single(users);

            var createdUser = _context.Users.GetSingleAsync(u => u.Email == userEmail);
            Assert.NotNull(createdUser);
        }

        ///<remarks>
        /// I didn't use using block because arises await-disposable problem 
        ///</remarks>
        [Fact]
        public async Task EntrySavedAfterAdd()
        {
            // Arrange
            IEnumerable<Charity> charities;
            var newCharity = new Charity
            {
                Name = "SpaceX"
            };

            // Act
            _context.Charities.Add(newCharity);
            await _context.CommitAsync(CancellationToken.None);
            charities = await _context.Charities.GetAllAsync();

            // Assert
            Assert.True(charities.Any());
        }

        [Fact]
        public async Task EntryNotSaveIfContextNotCommit()
        {
            // Arrange
            IEnumerable<Volunteer> volunteers;

            // Act
            _context.Volunteers.Add(new Volunteer());
            volunteers = await _context.Volunteers.GetAllAsync();

            // Assert
            Assert.False(volunteers.Any());
        }

        [Fact]
        public async Task EntryIsUpdatedAfterChangeProperty()
        {
            // Arrange
            User findByUpdated;
            const string emailBeforeUpdate = "testAdd@hotmail.com";
            const string emailAfterUpdate = "testUpdate@hotmail.com";

            // Act

            _context.Users.Add(new User
            {
                Email = emailBeforeUpdate,
                Password = "X493hello",
                UserTypeId = UserType.Administrator.Id
            });
            await _context.CommitAsync(CancellationToken.None);

            User addedUser = await _context.Users.GetSingleAsync(u => u.Email == emailBeforeUpdate);
            addedUser.Email = emailAfterUpdate;

            _context.Users.Update(addedUser);
            await _context.CommitAsync(CancellationToken.None);

            findByUpdated = await _context.Users.GetSingleAsync(u => u.Email == emailAfterUpdate);

            // Assert
            Assert.NotNull(findByUpdated);
            Assert.Equal(emailAfterUpdate, findByUpdated.Email);
        }

        [Fact]
        public async Task EntryNotExistsAfterDelete()
        {
            // Arrange
            const string eventTypeId = "FM";
            var eventType = new EventType
            {
                Id = eventTypeId,
                Name = "Full marathon"
            };

            // Act

            var eventTypeRepo = (IRepository<EventType>) _context.EventTypes;

            eventTypeRepo.Add(eventType);
            await _context.CommitAsync(CancellationToken.None);

            eventTypeRepo.Remove(eventType);
            await _context.CommitAsync(CancellationToken.None);

            eventType = await eventTypeRepo.GetSingleAsync(e => e.Id == eventTypeId);

            // Assert
            Assert.Null(eventType);
        }

        [Fact]
        public async Task ContextRestoreValuePropertiesAfterRollback()
        {
            // Arrange
            const string countryName = "France";
            var country = new Country
            {
                Id = "FR",
                Name = countryName,
                Flag = new byte[] { 00, 00, 00 }
            };

            // Act

            ((IRepository<Country>)_context.Countries).Add(country);
            await _context.CommitAsync(CancellationToken.None);

            country.Name = "Russia";

            _context.Rollback();

            // Assert
            Assert.Equal(countryName, country.Name);
        }

        [Fact]
        public async Task ContextCachesLastReceivedResults()
        {
            // Arrange
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan beforeCache, afterCache;

            // Generate random list of entries
            IEnumerable<User> users = Enumerable.Range(1, 100)
                .Select(u => new User
                {
                    Email = u.ToString(),
                    Password = u.ToString(),
                    UserTypeId = UserType.Coordinator.Id
                });

            // Act

            foreach (User user in users)
                _context.Users.Add(user);
            await _context.CommitAsync(CancellationToken.None);

            stopwatch.Start();
            await _context.Users.GetAllAsync();
            stopwatch.Stop();
            beforeCache = stopwatch.Elapsed;

            stopwatch.Reset();

            stopwatch.Start();
            await _context.Users.GetAllAsync();
            stopwatch.Stop();
            afterCache = stopwatch.Elapsed;

            Console.WriteLine($"Test name: {nameof(ContextCachesLastReceivedResults)}; Before cache: {beforeCache.Milliseconds} ms.");
            Console.WriteLine($"Test name: {nameof(ContextCachesLastReceivedResults)}; After cache: {afterCache.Milliseconds} ms.");

            // Assert
            Assert.True(afterCache < beforeCache);
        }
    }
}
