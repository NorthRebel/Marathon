using Marathon.Domain.Common;

namespace Marathon.DAL.Repositories
{
    /// <summary>
    /// Source: https://blogs.msdn.microsoft.com/mrtechnocal/2014/03/16/asynchronous-repositories/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IReadOnlyRepository<T> where T : IBaseEntity
    {
        void Add(T item);
        void Remove(T item);
        void Update(T item);
    }
}
