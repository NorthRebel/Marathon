namespace Marathon.BAL.Repositories
{
    using System;
    using System.Linq;
    using Domain.Common;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Source: https://blogs.msdn.microsoft.com/mrtechnocal/2014/03/16/asynchronous-repositories/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReadOnlyRepository<T> where T : IBaseEntity
    {
        Task<IEnumerable<T>> GetAsync(Func<IQueryable<T>, IQueryable<T>> queryShaper,
            CancellationToken cancellationToken);

        Task<TResult> GetAsync<TResult>(Func<IQueryable<T>, TResult> queryShaper, CancellationToken cancellationToken);
    }
}
