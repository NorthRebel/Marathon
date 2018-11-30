namespace Marathon.Domain.Common
{
    /// <summary>
    /// Adds necessary identity property for entity
    /// </summary>
    /// <typeparam name="TKey">Type of entity identity property</typeparam>
    public interface IEntity<TKey> : IBaseEntity
    {
        TKey Id { get; set; }
    }
}
