using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;
using Marathon.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Marathon.Persistence.Infrastructure
{
    using Domain.Entities;

    /// <summary>
    /// UoW implementation for EF Core
    /// Source: https://medium.com/@utterbbq/c-unitofwork-and-repository-pattern-305cd8ecfa7a
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool HasPendingChanges => _dbContext.ChangeTracker.HasChanges();

        #region Repositories

        public IReadOnlyRepository<UserType> UserTypes => new Repository<UserType>(_dbContext);
        public IRepository<User> Users => new Repository<User>(_dbContext);
        public IRepository<Runner> Runners => new Repository<Runner>(_dbContext);
        public IReadOnlyRepository<Gender> Genders => new Repository<Gender>(_dbContext);
        public IRepository<Volunteer> Volunteers => new Repository<Volunteer>(_dbContext);
        public IReadOnlyRepository<Country> Countries => new Repository<Country>(_dbContext);
        public IRepository<MarathonSignUp> MarathonSignUps => new Repository<MarathonSignUp>(_dbContext);
        public IReadOnlyRepository<SignUpStatus> SignUpStatuses => new Repository<SignUpStatus>(_dbContext);
        public IRepository<RaceKitOption> RaceKitOptions => new Repository<RaceKitOption>(_dbContext);
        public IRepository<RaceKitItem> RaceKitItems => new Repository<RaceKitItem>(_dbContext);
        public IRepository<RaceKitOptionItem> RaceKitOptionItems => new Repository<RaceKitOptionItem>(_dbContext);
        public IRepository<Charity> Charities => new Repository<Charity>(_dbContext);
        public IRepository<Sponsorship> Sponsorships => new Repository<Sponsorship>(_dbContext);
        public IRepository<SignUpMarathonEvent> SignUpMarathonEvents => new Repository<SignUpMarathonEvent>(_dbContext);
        public IRepository<Event> Events => new Repository<Event>(_dbContext);
        public IReadOnlyRepository<EventType> EventTypes => new Repository<EventType>(_dbContext);
        public IRepository<Marathon> Marathons => new Repository<Marathon>(_dbContext);

        #endregion

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Rollback()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }

        public Task CommitAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
