﻿using System.IO;
using Newtonsoft.Json;
using Marathon.Domain.Common;
using Marathon.DAL.Repositories;
using System.Collections.Generic;

namespace Marathon.Tests.DAL.Extensions
{
    /// <summary>
    /// Import from external sources extensions for <see cref="IRepository{T}"/>
    /// </summary>
    public static class RepositoryExtensions
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
    }
}
