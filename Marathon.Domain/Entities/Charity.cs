using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    /// <summary>
    /// Details of the <see cref="Charity"/>
    /// </summary>
    public sealed class Charity : IEntity
    {
        public Charity()
        {
            Registrations = new HashSet<Registration>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Logo { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
