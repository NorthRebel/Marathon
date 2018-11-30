using System;
using System.Linq;
using System.Threading;
using Marathon.Domain.Common;
using System.Threading.Tasks;
using Marathon.DAL.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Marathon.Persistence.Infrastructure
{
    /// <summary>
    /// Implementation of generic read-write repository
    /// </summary>
    /// <typeparam name="T">Type of database entity</typeparam>
    public sealed class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly DbContext _dbContext;

        private DbSet<T> DbSet => _dbContext.Set<T>();

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<T>> GetAsync(Func<IQueryable<T>, IQueryable<T>> queryShaper, CancellationToken cancellationToken)
        {
            return Task.Run(() => queryShaper(DbSet.AsQueryable()).AsEnumerable(), cancellationToken);
        }

        public Task<TResult> GetAsync<TResult>(Func<IQueryable<T>, TResult> queryShaper, CancellationToken cancellationToken)
        {
            return Task.Run(() => queryShaper(DbSet.AsQueryable()), cancellationToken);
        }

        public void Add(T item)
        {
            DbSet.Add(item);
        }

        public void Remove(T item)
        {
            DbSet.Remove(item);
        }

        public void Update(T item)
        {
            DbSet.Update(item);
        }
    }
}
