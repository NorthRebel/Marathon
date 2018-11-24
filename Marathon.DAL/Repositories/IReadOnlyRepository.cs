﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Domain.Common;
using System.Collections.Generic;

namespace Marathon.DAL.Repositories
{
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
