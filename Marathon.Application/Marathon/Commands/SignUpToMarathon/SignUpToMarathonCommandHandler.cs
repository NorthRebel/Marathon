using System;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;
using Marathon.Domain.Entities;
using System.Collections.Generic;
using Marathon.Application.Event.Exceptions;
using Marathon.Application.Event.Queries.GetEventsByTypes;
using Marathon.Application.Marathon.Queries.GetSignUpStatus;
using Marathon.Application.RaceKitOption.Queries.GetCostOfSelectedRaceKitOption;

namespace Marathon.Application.Marathon.Commands.SignUpToMarathon
{
    /// <summary>
    /// Handles <see cref="SignUpToMarathonCommand"/>
    /// </summary>
    public sealed class SignUpToMarathonCommandHandler : IRequestHandler<SignUpToMarathonCommand, Unit>
    {
        private readonly IUnitOfWork _dbContext;

        private readonly IRequestHandler<GetSignUpStatusQuery, byte> _marathonSignUpStatusFinder;
        private readonly IRequestHandler<GetEventsByTypesQuery, EventsListViewModel> _eventsOfSelectedTypes;
        private readonly IRequestHandler<GetCostOfSelectedRaceKitOptionQuery, decimal> _raceKitOptionCostHandler;

        public SignUpToMarathonCommandHandler(IUnitOfWorkFactory uowFactory,
            IRequestHandler<GetSignUpStatusQuery, byte> marathonSignUpStatusFinder,
            IRequestHandler<GetEventsByTypesQuery, EventsListViewModel> eventsOfSelectedTypes,
            IRequestHandler<GetCostOfSelectedRaceKitOptionQuery, decimal> raceKitOptionCostHandler)
        {
            _dbContext = uowFactory.Create();

            _marathonSignUpStatusFinder = marathonSignUpStatusFinder;
            _eventsOfSelectedTypes = eventsOfSelectedTypes;
            _raceKitOptionCostHandler = raceKitOptionCostHandler;
        }

        public async Task<Unit> Handle(SignUpToMarathonCommand request, CancellationToken cancellationToken)
        {
            EventsListViewModel eventsListViewModel = await GetEventsOfSelectedTypes(request.EventTypeIds, cancellationToken);

            uint signUpId = await SignUpRunnerToMarathon(request, GetEventsTotalCost(eventsListViewModel), cancellationToken);

            AssignEventsOfSignUp(eventsListViewModel, signUpId);

            // TODO: Add race kit items decrease functionality after confirm payment of runner

            await _dbContext.CommitAsync(cancellationToken);

            return Unit.Value;
        }

        #region Command handler helpers

        private async Task<EventsListViewModel> GetEventsOfSelectedTypes(IEnumerable<string> eventTypeIds, CancellationToken cancellationToken)
        {
            var events = await _eventsOfSelectedTypes.Handle(new GetEventsByTypesQuery(eventTypeIds), cancellationToken);

            if (!events.Events.Any())
                throw new NoEventsOfSelectedTypesException();

            return events;
        }

        /// <summary>
        /// Converts <see cref="EventsListViewModel"/> to <see cref="SignUpMarathonEvent"/> entities of current marathon sign up and save it to signUpEvent repository
        /// </summary>
        private void AssignEventsOfSignUp(EventsListViewModel eventsListViewModel, uint signUpId)
        {
            IEnumerable<SignUpMarathonEvent> signUpEvents = SignUpMarathonEventsProjection(eventsListViewModel, signUpId);

            foreach (SignUpMarathonEvent signUpEvent in signUpEvents)
                _dbContext.SignUpMarathonEvents.Add(signUpEvent);
        }

        /// <summary>
        /// Converts <see cref="EventsListViewModel"/> to <see cref="SignUpMarathonEvent"/> entities of current marathon sign up
        /// </summary>
        private IEnumerable<SignUpMarathonEvent> SignUpMarathonEventsProjection(EventsListViewModel eventsListViewModel, uint signUpId)
        {
            return eventsListViewModel.Events.Select(e => new SignUpMarathonEvent
            {
                EventId = e.Id,
                SignUpId = signUpId
            });
        }

        /// <summary>
        /// Converts <see cref="SignUpToMarathonCommand"/> DTO to <see cref="MarathonSignUp"/> entity and save it to sign up repository
        /// </summary>
        private async Task<uint> SignUpRunnerToMarathon(SignUpToMarathonCommand request, decimal eventsTotalCost, CancellationToken cancellationToken)
        {
            MarathonSignUp marathonSignUp = await SignUpProjection(request, eventsTotalCost, cancellationToken);

            _dbContext.MarathonSignUps.Add(marathonSignUp);

            return marathonSignUp.Id;
        }

        /// <summary>
        /// Converts <see cref="SignUpToMarathonCommand"/> DTO to <see cref="MarathonSignUp"/> entity
        /// </summary>
        private async Task<MarathonSignUp> SignUpProjection(SignUpToMarathonCommand request, decimal eventsTotalCost, CancellationToken cancellationToken)
        {
            return new MarathonSignUp
            {
                SignUpDate = DateTime.UtcNow,
                SponsorshipTarget = request.SponsorshipTarget,
                RunnerId = request.RunnerId,
                CharityId = request.CharityId,
                RaceKitOptionId = request.RaceKitOptionId,
                SignUpStatusId = await  GetInitialMarathonSignUpStatus(cancellationToken),
                Cost = await GetCostOfSelectedRaceKitOption(request.RaceKitOptionId, cancellationToken) + eventsTotalCost
            };
        }

        public async Task<decimal> GetCostOfSelectedRaceKitOption(char raceKitOptionId, CancellationToken cancellationToken)
        {
            return await _raceKitOptionCostHandler.Handle(new GetCostOfSelectedRaceKitOptionQuery(raceKitOptionId),
                cancellationToken);
        }

        private decimal GetEventsTotalCost(EventsListViewModel eventsListViewModel)
        {
            return eventsListViewModel.Events.Sum(e => e.Cost);
        }

        private async Task<byte> GetInitialMarathonSignUpStatus(CancellationToken cancellationToken)
        {
            return await _marathonSignUpStatusFinder.Handle(new GetSignUpStatusQuery(Domain.Enumerations.SignUpStatus.SignedUp.ToString()), cancellationToken);
        }

        #endregion
    }
}
