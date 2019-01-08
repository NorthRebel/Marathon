using Microsoft.EntityFrameworkCore;
using Marathon.Persistence.Infrastructure;

namespace Marathon.Persistence
{
    public sealed class MarathonDbContextFactory : DesignTimeDbContextFactoryBase<MarathonDbContext>
    {
        protected override MarathonDbContext CreateNewInstance(DbContextOptions<MarathonDbContext> options)
        {
            return new MarathonDbContext(options);
        }
    }
}
