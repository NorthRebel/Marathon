using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Marathon.Domain.Common;
using System.Collections.Generic;
using Marathon.Application.Repositories;

namespace Marathon.Application.Tests.Infrastructure.Repositories
{
    /// <summary>
    /// Import from external sources extensions for <see cref="IRepositoryMock{TRepository,TEntity}"/>
    /// </summary>
    public static class RepositoryMockExtensions 
    {
        /// <summary>
        /// Imports repository items from external JSON file
        /// </summary>
        /// <typeparam name="TRepository">Repository which contains items</typeparam>
        /// <typeparam name="TEntity">Entity type import</typeparam>
        /// <param name="repositoryMock">Target repository</param>
        /// <param name="filePath">Path to JSON file</param>
        /// <returns>Repository with imported items</returns>
        public static IRepositoryMock<TRepository, TEntity> FromJson<TRepository, TEntity>(this IRepositoryMock<TRepository, TEntity> repositoryMock, string filePath) where TRepository : class,
            IReadOnlyRepository<TEntity> where TEntity : IEntity
        {
            // Get the absolute path to the JSON file
            var path = Path.IsPathRooted(filePath)
                ? filePath
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), filePath);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find file at path: {path}");
            }

            // Load the file
            var fileData = File.ReadAllText(filePath);

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
        public static IRepositoryMock<TRepository, TEntity> FromCollection<TRepository, TEntity>(this IRepositoryMock<TRepository, TEntity> repositoryMock, IEnumerable<TEntity> collection) where TRepository : class,
            IReadOnlyRepository<TEntity> where TEntity : IEntity
        {
            if (!repositoryMock.Items.Any())
                repositoryMock.Items = collection.ToList();
            else
                repositoryMock.Items.AddRange(collection);

            return repositoryMock;
        }
    }
}
