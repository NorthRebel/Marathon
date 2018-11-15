using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    /// <summary>
    /// Details of the <see cref="Sponsorship"/>
    /// </summary>
    public sealed class Sponsorship : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long RegistrationId { get; set; }
        public decimal Ammount { get; set; }

        public MarathonSignUp Registration { get; set; }
    }
}
