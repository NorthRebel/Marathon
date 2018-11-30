using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    /// <summary>
    /// Details of the <see cref="Volunteer"/>
    /// </summary>
    public sealed class Volunteer : IEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryCode { get; set; }
        public long GenderId { get; set; }
        
        public Country Country { get; set; }
        public Gender Gender { get; set; }
    }
}
