using System;
using System.Linq;
using System.Threading;
using Marathon.Domain.Common;
using System.Threading.Tasks;
using Marathon.DAL.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Marathon.DAL.Tests.Infrastructure
{
    /// <summary>
    /// Implementation of generic read-write repository
    /// </summary>
    /// <typeparam name="T">Type of database entity</typeparam>
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly DbContext _dbContext;

        private DbSet<T> _dbSet => _dbContext.Set<T>();

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<T>> GetAsync(Func<IQueryable<T>, IQueryable<T>> queryShaper, CancellationToken cancellationToken)
        {
            return Task.Run(() => queryShaper(_dbSet.AsQueryable()).AsEnumerable(), cancellationToken);
        }

        public Task<TResult> GetAsync<TResult>(Func<IQueryable<T>, TResult> queryShaper, CancellationToken cancellationToken)
        {
            return Task.Run(() => queryShaper(_dbSet.AsQueryable()), cancellationToken);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }
    }
}
