using Xunit;

namespace Marathon.Tests.DAL.Infrastructure
{
    [CollectionDefinition(nameof(UnitOfWorkCollection))]
    public class UnitOfWorkCollection : ICollectionFixture<UnitOfWorkFixture>
    {
    }
}
