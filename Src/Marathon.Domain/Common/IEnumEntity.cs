namespace Marathon.Domain.Common
{
    /// <summary>
    /// Fields list for entity which have behavior as linked enumeration
    /// </summary>
    /// <typeparam name="TKey">Type of entity identity property</typeparam>
    public interface IEnumEntity<TKey> : IEntity<TKey>
    {
        string Name { get; set; }
    }
}
