using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace Marathon.Domain.Enumerations
{
    /// <summary>
    /// Base class of linked enumeration for domain entities
    /// </summary>
    public abstract class Enumeration
    {
        public long Id { get; }
        public string Name { get; }

        protected Enumeration(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }
    }
}
