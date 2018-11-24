namespace Marathon.BAL.UnitOfWork
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the behavior for a unit of work.
    /// Source: https://blogs.msdn.microsoft.com/mrtechnocal/2014/04/18/unit-of-work-expanded/
    /// </summary>
    public interface IBaseUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether there are any pending, uncommitted changes.
        /// </summary>
        /// <value>True if there are any pending uncommitted changes; otherwise, false.</value>
        bool HasPendingChanges { get; }

        /// <summary>
        /// Rolls back all pending units of work.
        /// </summary>
        void Rollback();

        /// <summary>
        /// Commits all pending units of work asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> that can be used to cancel the operation.</param>
        /// <returns>A <see cref="Task">task</see> representing the commit operation.</returns>
        Task CommitAsync(CancellationToken cancellationToken);
    }
}
