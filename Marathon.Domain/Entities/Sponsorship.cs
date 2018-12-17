using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    /// <summary>
    /// Details of the <see cref="Sponsorship"/>
    /// </summary>
    public sealed class Sponsorship : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SignUpId { get; set; }
        public decimal Amount { get; set; }

        public MarathonSignUp SignUp { get; set; }
    }
}
