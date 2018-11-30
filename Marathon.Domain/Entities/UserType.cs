using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    /// <summary>
    /// The type of user that divide rights to use application
    /// </summary>
    public sealed class UserType : IEntity<char>
    {
        public UserType()
        {
            Users = new HashSet<User>();
        }

        public char Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
