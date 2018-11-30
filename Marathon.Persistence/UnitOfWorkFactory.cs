using System;
using System.Data;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Marathon.Persistence.Exceptions;
using Marathon.Persistence.Infrastructure;

namespace Marathon.Persistence
{
    /// <summary>
    /// Implementation of data source abstraction by <see cref="IUnitOfWork"/>
    /// </summary>
    public sealed class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly DbContext _context;

        public UnitOfWorkFactory(DbContext context)
        {
            _context = context;
        }

        public IUnitOfWork Create(IsolationLevel isolationLevel)
        {
            Task.Run(() => SetIsolationLevel(isolationLevel));
            return new UnitOfWork(_context);
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(_context);
        }

        /// <summary>
        /// Set locking and row versioning behavior of Transact-SQL statements issued by a connection to SQL Server.
        /// </summary>
        /// <param name="isolationLevel">Transaction locking behavior for the connection</param>
        /// <remarks>
        /// Intended for Microsoft SQL Server (version 2008 and above)
        /// </remarks>
        // TODO: Add support for other providers
        private async Task SetIsolationLevel(IsolationLevel isolationLevel)
        {
            string sqlCommand = "SET TRANSACTION ISOLATION LEVEL ";

            switch (isolationLevel)
            {
                case IsolationLevel.Chaos:
                    break;
                case IsolationLevel.ReadCommitted:
                    sqlCommand += "READ COMMITTED";
                    break;
                case IsolationLevel.ReadUncommitted:
                    sqlCommand += "READ UNCOMMITTED";
                    break;
                case IsolationLevel.RepeatableRead:
                    sqlCommand += "REPEATABLE READ";
                    break;
                case IsolationLevel.Serializable:
                    sqlCommand += "SERIALIZABLE";
                    break;
                case IsolationLevel.Snapshot:
                    sqlCommand += "SNAPSHOT";
                    break;
                case IsolationLevel.Unspecified:
                    throw new NotSupportedIsolationLevelException(_context.Database.ProviderName, isolationLevel);
                default:
                    throw new ArgumentOutOfRangeException(nameof(isolationLevel), isolationLevel, null);
            }

            await _context.Database.ExecuteSqlCommandAsync(sqlCommand);
        }
    }
}
