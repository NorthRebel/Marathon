﻿using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Marathon.Domain.Common;
using System.Collections.Generic;
using Marathon.Application.Repositories;
using Marathon.Application.Tests.Extensions;

namespace Marathon.Application.Tests.Infrastructure.Repositories.BaseEntity
{
    /// <summary>
    /// Import from external sources extensions for <see cref="IRepositoryMock{TRepository,TEntity}"/>
    /// </summary>
    public static class BaseRepositoryMockExtensions 
    {
        /// <summary>
        /// Imports repository items from external JSON file
        /// </summary>
        /// <typeparam name="TRepository">Repository which contains items</typeparam>
        /// <typeparam name="TEntity">Entity type import</typeparam>
        /// <param name="repositoryMock">Target repository</param>
        /// <param name="filePath">Path to JSON file</param>
        /// <returns>Repository with imported items</returns>
        public static IBaseRepositoryMock<TRepository, TEntity> FromJson<TRepository, TEntity>(this IBaseRepositoryMock<TRepository, TEntity> repositoryMock, string filePath) where TRepository : class,
            IReadOnlyRepository<TEntity> where TEntity : IBaseEntity
        {
            // Load the file
            var fileData = File.ReadAllText(PathExtensions.GetAbsolutePath(filePath));

            if (!repositoryMock.Items.Any())
                repositoryMock.Items = JsonConvert.DeserializeObject<List<TEntity>>(fileData);
            else
                repositoryMock.Items.AddRange(JsonConvert.DeserializeObject<IEnumerable<TEntity>>(fileData));

            return repositoryMock;
        }

        /// <summary>
        /// Imports repository items from in-memory collection
        /// </summary>
        /// <typeparam name="TRepository">Repository which contains items</typeparam>
        /// <typeparam name="TEntity">Entity type import</typeparam>
        /// <param name="repositoryMock">Target repository</param>
        /// <param name="collection">In-memory collection to import</param>
        /// <returns>Repository with imported items</returns>
        public static IBaseRepositoryMock<TRepository, TEntity> FromCollection<TRepository, TEntity>(this IBaseRepositoryMock<TRepository, TEntity> repositoryMock, IEnumerable<TEntity> collection) where TRepository : class,
            IReadOnlyRepository<TEntity> where TEntity : IBaseEntity
        {
            if (!repositoryMock.Items.Any())
                repositoryMock.Items = collection.ToList();
            else
                repositoryMock.Items.AddRange(collection);

            return repositoryMock;
        }
    }
}
