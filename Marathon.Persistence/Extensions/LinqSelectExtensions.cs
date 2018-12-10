using System;
using System.Linq;
using Marathon.Domain.Common;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Marathon.Persistence.Extensions
{
    /// <summary>
    /// Extension methods for LINQ constructions
    /// </summary>
    public static class LinqSelectExtensions
    {
        /// <summary>
        /// Projects set of entity instances to list of primary keys
        /// </summary>
        /// <typeparam name="TEntity">Entity of context</typeparam>
        /// <typeparam name="TKey">Key field of entity (single)</typeparam>
        /// <param name="set">Set of entities</param>
        public static IEnumerable<TKey> GetKeysFromSet<TEntity, TKey>(this DbSet<TEntity> set) where TEntity : class, IEntity<TKey>
        {
            return set.Select(x => x.Id).AsEnumerable();
        }
        
        /// <summary>
        /// Selects object to another type with avoiding exceptions
        /// </summary>
        /// <typeparam name="TSource">Object type</typeparam>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="enumerable">List of objects</param>
        /// <param name="selector">Expression to select object to another type</param>
        public static IEnumerable<SelectTryResult<TSource, TResult>> SelectTry<TSource, TResult>(this IEnumerable<TSource> enumerable, Func<TSource, TResult> selector)
        {
            foreach (TSource element in enumerable)
            {
                SelectTryResult<TSource, TResult> returnedValue;
                try
                {
                    returnedValue = new SelectTryResult<TSource, TResult>(element, selector(element), null);
                }
                catch (Exception ex)
                {
                    returnedValue = new SelectTryResult<TSource, TResult>(element, default(TResult), ex);
                }
                yield return returnedValue;
            }
        }

        /// <summary>
        /// Sets next actions in case of caught an exception
        /// </summary>
        /// <typeparam name="TSource">Object type</typeparam>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="enumerable">List of objects</param>
        /// <param name="exceptionHandler">Method which will handle caught exception</param>
        public static IEnumerable<TResult> OnCaughtException<TSource, TResult>(this IEnumerable<SelectTryResult<TSource, TResult>> enumerable, Func<Exception, TResult> exceptionHandler)
        {
            return enumerable.Select(x => x.CaughtException == null ? x.Result : exceptionHandler(x.CaughtException));
        }

        /// <summary>
        /// Sets next actions in case of caught an exception and store initial form of object
        /// </summary>
        /// <typeparam name="TSource">Object type</typeparam>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="enumerable">List of objects</param>
        /// <param name="exceptionHandler">Method which will handle caught exception</param>
        public static IEnumerable<TResult> OnCaughtException<TSource, TResult>(this IEnumerable<SelectTryResult<TSource, TResult>> enumerable, Func<TSource, Exception, TResult> exceptionHandler)
        {
            return enumerable.Select(x => x.CaughtException == null ? x.Result : exceptionHandler(x.Source, x.CaughtException));
        }

        /// <summary>
        /// Nested class which contains initial object type and his new projection
        /// If projection fails caught exception will be save for next handling
        /// </summary>
        /// <typeparam name="TSource">Initial object type</typeparam>
        /// <typeparam name="TResult">Projected object</typeparam>
        public class SelectTryResult<TSource, TResult>
        {
            internal SelectTryResult(TSource source, TResult result, Exception exception)
            {
                Source = source;
                Result = result;
                CaughtException = exception;
            }

            public TSource Source { get; }
            public TResult Result { get; }
            public Exception CaughtException { get; }
        }
    }
}
