using Marathon.Application.Charity.Queries.GetCharityList;

namespace Marathon.Application.Charity.Models
{
    /// <summary>
    /// DTO for <see cref="GetCharityListQuery"/>
    /// </summary>
    public sealed class CharityPreviewDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Logo { get; set; }
    }
}
