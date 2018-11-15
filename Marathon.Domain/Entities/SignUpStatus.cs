using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public sealed class SignUpStatus : IEntity
    {
        public SignUpStatus()
        {
            SignUps = new HashSet<MarathonSignUp>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<MarathonSignUp> SignUps { get; set; }
    }
}
