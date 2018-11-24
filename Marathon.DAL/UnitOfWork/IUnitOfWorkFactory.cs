using System.Data;

namespace Marathon.DAL.UnitOfWork
{
    /// <summary>
    /// Factory methods for create <see cref="IUnitOfWork"/>
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Creates instance of <see cref="IUnitOfWork"/> with specific database isolation level
        /// </summary>
        /// <param name="isolationLevel">The database isolation level with which the underlying store transaction will be created</param>
        /// <returns>Instance of <see cref="IUnitOfWork"/></returns>
        IUnitOfWork Create(IsolationLevel isolationLevel);

        /// <summary>
        /// Creates instance of <see cref="IUnitOfWork"/> with default value of <see cref="IsolationLevel"/> (ReadCommited)
        /// </summary>
        /// <returns>Instance of <see cref="IUnitOfWork"/></returns>
        IUnitOfWork Create();
    }
}
