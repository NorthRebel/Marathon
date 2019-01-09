using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    /// <summary>
    /// Gender of people
    /// </summary>
    public sealed class Gender : IEnumEntity<char>
    {
        public Gender()
        {
            Runners = new HashSet<Runner>();
            Volunteers = new HashSet<Volunteer>();
        }

        public char Id { get; set; }
        public string Name { get; set; }

        public ICollection<Runner> Runners { get; set; }
        public ICollection<Volunteer> Volunteers { get; set; }
    }
}
