using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public sealed class RegistrationStatus : IEntity
    {
        public RegistrationStatus()
        {
            Registrations = new HashSet<Registration>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
