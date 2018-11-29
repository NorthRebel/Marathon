using System.IO;
using Newtonsoft.Json;
using Marathon.Domain.Common;
using Marathon.DAL.Repositories;
using System.Collections.Generic;

namespace Marathon.Application.Tests.Extensions
{
    /// <summary>
    /// Import from external sources extensions for <see cref="IRepository{T}"/>
    /// </summary>
    internal static class RepositoryExtensions
    {
        /// <summary>
        /// Imports repository items from external JSON file
        /// </summary>
        /// <typeparam name="TEntity">Entity type import</typeparam>
        /// <param name="repository">Target repository</param>
        /// <param name="filePath">Path to JSON file</param>
        public static void ImportFromJson<TEntity>(this IRepository<TEntity> repository, string filePath) where TEntity : IBaseEntity
        {
            // Load the file
            var fileData = File.ReadAllText(PathExtensions.GetAbsolutePath(filePath));

            foreach (TEntity entry in JsonConvert.DeserializeObject<IEnumerable<TEntity>>(fileData))
                repository.Add(entry);
        }

        /// <summary>
        /// Imports repository items from in-memory collection
        /// </summary>
        /// <typeparam name="TEntity">Entity type import</typeparam>
        /// <param name="repository">Target repository</param>
        /// <param name="collection">In-memory collection to import</param>
        public static void ImportFromCollection<TEntity>(this IRepository<TEntity> repository, IEnumerable<TEntity> collection) where TEntity : IBaseEntity
        {
            foreach (TEntity entry in collection)
                repository.Add(entry);
        }
    }
}
