namespace Marathon.BAL.Repositories
{
    using Domain.Common;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Source: https://blogs.msdn.microsoft.com/mrtechnocal/2014/03/16/asynchronous-repositories/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IReadOnlyRepository<T> where T : IBaseEntity
    {
        bool HasPendingChanges { get; }
        void Add(T item);
        void Remove(T item);
        void Update(T item);
        void DiscardChanges();
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
