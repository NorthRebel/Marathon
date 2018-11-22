using MediatR;
using System.Collections.Generic;
using Marathon.Application.Charity.Models;

namespace Marathon.Application.Charity.Queries.GetCharityList
{
    /// <summary>
    /// Gets collection of <see cref="CharityPreviewDto"/>
    /// </summary>
    public sealed class GetCharityListQuery : IRequest<IEnumerable<CharityPreviewDto>>
    {
    }
}
