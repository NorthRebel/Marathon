﻿using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    /// <summary>
    /// Details of the <see cref="Sponsorship"/>
    /// </summary>
    public sealed class Sponsorship : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long SignUpId { get; set; }
        public decimal Amount { get; set; }

        public MarathonSignUp SignUp { get; set; }
    }
}
