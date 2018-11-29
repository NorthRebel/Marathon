using System;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;

namespace Marathon.Tests.DAL.Extensions
{
    /// <summary>
    /// Thread-safe unitOfWork initializer
    /// </summary>
    public static class UoWInitializer
    {
        private static object _lock = new object();
        private static bool _initialized;

        public static void Initialize(this IUnitOfWork context, Func<IUnitOfWork, Task> seedData)
        {
            if (!_initialized)
            {
                lock (_lock)
                {
                    if (_initialized)
                        return;

                    _initialized = true;

                    seedData(context);
                }
            }
        }
    }
}
