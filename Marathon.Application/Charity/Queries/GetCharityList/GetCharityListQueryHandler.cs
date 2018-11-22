using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Marathon.Application.Repositories;
using Marathon.Application.Charity.Models;

namespace Marathon.Application.Charity.Queries.GetCharityList
{
    using Domain.Entities;

    /// <summary>
    /// Handles <see cref="GetCharityListQuery"/>
    /// </summary>
    public sealed class GetCharityListQueryHandler : IRequestHandler<GetCharityListQuery, IEnumerable<CharityPreviewDto>>
    {
        private readonly IReadOnlyRepository<Charity> _charityRepository;

        public GetCharityListQueryHandler(IReadOnlyRepository<Charity> charityRepository)
        {
            _charityRepository = charityRepository;
        }

        public async Task<IEnumerable<CharityPreviewDto>> Handle(GetCharityListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Charity> charities = await GetCharities(cancellationToken);

            return charities.Select(DtoProjection);
        }

        #region Command handler helpers

        /// <summary>
        /// Converts <see cref="Charity"/> entity to <see cref="CharityPreviewDto"/>
        /// </summary>
        private CharityPreviewDto DtoProjection(Charity charity)
        {
            return new CharityPreviewDto
            {
                Name = charity.Name,
                Description = charity.Description,
                Logo = charity.Logo
            };
        }

        /// <summary>
        /// Gets all charities from charity repository
        /// </summary>
        private Task<IEnumerable<Charity>> GetCharities(CancellationToken cancellationToken)
        {
            return _charityRepository.GetAsync(charity => charity, cancellationToken);
        }

        #endregion
    }
}
