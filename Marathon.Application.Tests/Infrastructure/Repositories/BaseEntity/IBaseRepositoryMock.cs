using Marathon.Domain.Common;
using System.Collections.Generic;
using Marathon.Application.Repositories;

namespace Marathon.Application.Tests.Infrastructure.Repositories.BaseEntity
{
    /// <summary>
    /// Mock for repositories with in-memory items collection
    /// where <typeparamref name="TEntity"/> is <see cref="IBaseEntity"/>
    /// </summary>
    /// <typeparam name="TRepository">Target repository</typeparam>
    /// <typeparam name="TEntity">Entity of repository which not contains default identity key</typeparam>
    public interface IBaseRepositoryMock<out TRepository, TEntity> where TRepository : class,
        IReadOnlyRepository<TEntity> where TEntity : IBaseEntity
    {
        List<TEntity> Items { get; set; }

        /// <summary>
        /// Setup mocks for repository methods
        /// </summary>
        void SetupMethods();
    }
}
