using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    /// <summary>
    /// Details of application user
    /// </summary>
    public sealed class User : IEntity<int>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char UserTypeId { get; set; }

        public UserType UserType { get; set; }
        public Runner Runner { get; set; }
    }
}
