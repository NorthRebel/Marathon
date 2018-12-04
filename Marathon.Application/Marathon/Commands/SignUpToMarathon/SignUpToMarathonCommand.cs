using MediatR;
using System.Collections.Generic;

namespace Marathon.Application.Marathon.Commands.SignUpToMarathon
{
    /// <summary>
    /// Command requirements for sign up runner to marathon event
    /// </summary>
    public sealed class SignUpToMarathonCommand : IRequest
    {
        public uint RunnerId { get; set; }
        public char RaceKitOptionId { get; set; }
        public IEnumerable<string> EventTypeIds { get; set; }
        public uint CharityId { get; set; }
        public decimal SponsorshipTarget { get; set; }
    }
}
