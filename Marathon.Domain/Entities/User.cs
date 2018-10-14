using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    /// <summary>
    /// Details of application user
    /// </summary>
    public sealed class User : IEntity
    {
        public User()
        {
            Runners = new HashSet<Runner>();
        }

        public long Id { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long RoleId { get; set; }

        public UserType UserType { get; set; }
        public ICollection<Runner> Runners { get; set; }
    }
}
