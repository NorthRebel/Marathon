namespace Marathon.Domain.Common
{
    /// <summary>
    /// Adds necessary identity property for entity
    /// </summary>
    public interface IEntity
    {
        long Id { get; set; }
    }
}
