namespace Marathon.Domain.Common
{
    /// <summary>
    /// Adds necessary identity property for entity
    /// </summary>
    public interface IEntity : IBaseEntity
    {
        long Id { get; set; }
    }
}
