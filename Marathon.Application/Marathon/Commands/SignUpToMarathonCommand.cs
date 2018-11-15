using System.Collections.Generic;
using MediatR;

namespace Marathon.Application.Marathon.Commands
{
    /// <summary>
    /// Command requirements for sign up runner to marathon event
    /// </summary>
    public sealed class SignUpToMarathonCommand : IRequest
    {
        public long RunnerId { get; set; }
        public long RaceKitOptionId { get; set; }
        public IEnumerable<long> EventTypeIds { get; set; }
        public long CharityId { get; set; }
        public decimal SponsorshipTarget { get; set; }
    }
}
