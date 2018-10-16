using System.Collections.Generic;
using System.Reflection;
using Marathon.Domain.Common;
using Newtonsoft.Json.Linq;

namespace Marathon.Application.Tests.Infrastructure
{
    /// <summary>
    /// In memory storage of entities for unit tests
    /// </summary>
    public interface IStorage<T> where T: IEntity
    {
        IEnumerable<T> Items { get; }
    }
}
