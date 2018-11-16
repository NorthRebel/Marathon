using Marathon.Domain.Common;
using System.Collections.Generic;
using Marathon.Application.Repositories;

namespace Marathon.Application.Tests.Infrastructure.Repositories
{
    /// <summary>
    /// Mock for repositories with in-memory items collection
    /// </summary>
    /// <typeparam name="TRepository">Target repository</typeparam>
    /// <typeparam name="TEntity">Entity of repository</typeparam>
    public interface IRepositoryMock<out TRepository, TEntity> where TRepository : class,
        IReadOnlyRepository<TEntity> where TEntity : IEntity
    {
        List<TEntity> Items { get; set; }

        /// <summary>
        /// Setup mocks for repository methods
        /// </summary>
        void SetupMethods();
    }
}
