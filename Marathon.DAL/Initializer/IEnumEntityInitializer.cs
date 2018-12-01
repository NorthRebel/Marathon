using System.Collections.Generic;
using Marathon.DAL.Repositories;
using Marathon.Domain.Enumerations;

namespace Marathon.DAL.Initializer
{
    using Domain.Common;
    using Domain.Entities;

    /// <summary>
    /// List of methods which should initialize repositories of entities which implement <see cref="IEnumEntity{TKey}"/>
    /// </summary>
    internal interface IEnumEntityInitializer
    {
        /// <summary>
        /// Seeds <see cref="UserType"/> repository
        /// </summary>
        void SeedUserTypes();

        /// <summary>
        /// Seeds <see cref="Gender"/> repository
        /// </summary>
        void SeedGenders();

        /// <summary>
        /// Seeds <see cref="SignUpStatus"/> repository
        /// </summary>
        void SeedSignUpStatuses();

        /// <summary>
        /// Seed repository with enum entities from defined enum
        /// </summary>
        /// <typeparam name="TEntity">Type of repository</typeparam>
        /// <typeparam name="TKey">Key field type of entity</typeparam>
        /// <typeparam name="TEntityEnum">Type of linked enumeration</typeparam>
        /// <param name="repository">Repository to initialize</param>
        /// <param name="items">Linked enumeration items</param>
        void SeedEnumeration<TEntity, TKey, TEntityEnum>(IReadOnlyRepository<TEntity> repository, IEnumerable<TEntityEnum> items)
            where TEntity : IEnumEntity<TKey>, new() where TEntityEnum : Enumeration<TKey, TEntity>;
    }
}
