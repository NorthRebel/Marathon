using System;
using System.Linq;
using System.Reflection;
using Marathon.Domain.Common;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Marathon.Domain.Enumerations
{
    /// <summary>
    /// Base class of linked enumeration for domain entities
    /// </summary>
    public abstract class Enumeration<TKey, TEntity> where TEntity : IEnumEntity<TKey>, new()
    {
        public TKey Id { get; }
        public string Name { get; }

        protected Enumeration(TKey id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration<TKey, TEntity>
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        /// <summary>
        /// Converts enumeration object to domain entity
        /// </summary>
        /// <returns>Domain entity</returns>
        public static Expression<Func<Enumeration<TKey, TEntity>, TEntity>> Projection
        {
            get
            {
                return enumEntity => new TEntity
                {
                    Id = enumEntity.Id,
                    Name = enumEntity.Name
                };
            }
        }

        public static TEntity Create(Enumeration<TKey, TEntity> customer)
        {
            return Projection.Compile().Invoke(customer);
        }
    }
}
