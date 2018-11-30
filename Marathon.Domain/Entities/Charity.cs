using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    /// <summary>
    /// Details of the <see cref="Charity"/>
    /// </summary>
    public sealed class Charity : IEntity<long>
    {
        public Charity()
        {
            SignUps = new HashSet<MarathonSignUp>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Logo { get; set; }

        public ICollection<MarathonSignUp> SignUps { get; set; }
    }
}
