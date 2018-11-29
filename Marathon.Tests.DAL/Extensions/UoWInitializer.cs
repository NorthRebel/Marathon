using System;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;

namespace Marathon.Tests.DAL.Extensions
{
    public static class UoWInitializer
    {
        public static void Initialize(this IUnitOfWork context, Func<IUnitOfWork, Task> seedData)
        {
            seedData(context);
        }
    }
}
