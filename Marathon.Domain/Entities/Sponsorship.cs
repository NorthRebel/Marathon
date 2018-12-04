using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    /// <summary>
    /// Details of the <see cref="Sponsorship"/>
    /// </summary>
    public sealed class Sponsorship : IEntity<uint>
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint SignUpId { get; set; }
        public decimal Amount { get; set; }

        public MarathonSignUp SignUp { get; set; }
    }
}
