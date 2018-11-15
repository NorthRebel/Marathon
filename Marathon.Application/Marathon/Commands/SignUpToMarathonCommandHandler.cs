using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Application.Event.Queries.GetEventsByTypes;
using Marathon.Application.Exceptions;
using Marathon.Application.Marathon.Queries;
using Marathon.Application.RaceKitOption.Queries.GetCostOfSelectedRaceKitOption;
using Marathon.Application.Repositories;
using Marathon.Domain.Entities;
using MediatR;

namespace Marathon.Application.Marathon.Commands
{
    /// <summary>
    /// Handles <see cref="SignUpToMarathonCommand"/>
    /// </summary>
    public sealed class SignUpToMarathonCommandHandler : IRequestHandler<SignUpToMarathonCommand, Unit>
    {
        private readonly IRepository<Registration> _registrationRepository;
        private readonly IRepository<RegistrationEvent> _registrationEventRepository;
        private readonly IRequestHandler<SignUpStatusQuery, long> _marathonSignUpStatusFinder;
        private readonly IRequestHandler<GetEventsByTypesQuery, EventsListViewModel> _eventsOfSelectedTypes;
        private readonly IRequestHandler<GetCostOfSelectedRaceKitOptionQuery, decimal> _raceKitOptionCostHandler;

        public SignUpToMarathonCommandHandler(IRepository<Registration> registrationRepository,
            IRepository<RegistrationEvent> registrationEventRepository,
            IRequestHandler<SignUpStatusQuery, long> marathonSignUpStatusFinder,
            IRequestHandler<GetEventsByTypesQuery, EventsListViewModel> eventsOfSelectedTypes,
            IRequestHandler<GetCostOfSelectedRaceKitOptionQuery, decimal> raceKitOptionCostHandler)
        {
            _registrationRepository = registrationRepository;
            _registrationEventRepository = registrationEventRepository;
            _marathonSignUpStatusFinder = marathonSignUpStatusFinder;
            _eventsOfSelectedTypes = eventsOfSelectedTypes;
            _raceKitOptionCostHandler = raceKitOptionCostHandler;
        }

        public async Task<Unit> Handle(SignUpToMarathonCommand request, CancellationToken cancellationToken)
        {
            EventsListViewModel eventsListViewModel = await GetEventsOfSelectedTypes(request.EventTypeIds, cancellationToken);

            long registrationId = await SignUpRunnerToMarathon(request, GetEventsTotalCost(eventsListViewModel), cancellationToken);

            await AssignEventsOfRegistration(eventsListViewModel, registrationId, cancellationToken);

            return Unit.Value;
        }

        #region Command handler helpers

        private async Task<EventsListViewModel> GetEventsOfSelectedTypes(IEnumerable<long> eventTypeIds, CancellationToken cancellationToken)
        {
            var events = await _eventsOfSelectedTypes.Handle(new GetEventsByTypesQuery(eventTypeIds), cancellationToken);

            if (!events.Events.Any())
                throw new NoEventsOfSelectedTypesException();

            // TODO: Add check max participants!!!

            return events;
        }

        /// <summary>
        /// Converts <see cref="EventsListViewModel"/> to <see cref="RegistrationEvent"/> entities of current registration and save it to registrationEvent repository
        /// </summary>
        private async Task AssignEventsOfRegistration(EventsListViewModel eventsListViewModel, long registrationId, CancellationToken cancellationToken)
        {
            IEnumerable<RegistrationEvent> registrationEvents = RegistrationEventsProjection(eventsListViewModel, registrationId);

            foreach (RegistrationEvent registrationEvent in registrationEvents)
                _registrationEventRepository.Add(registrationEvent);

            await _registrationEventRepository.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Converts <see cref="EventsListViewModel"/> to <see cref="RegistrationEvent"/> entities of current registration
        /// </summary>
        private IEnumerable<RegistrationEvent> RegistrationEventsProjection(EventsListViewModel eventsListViewModel, long registrationId)
        {
            return eventsListViewModel.Events.Select(e => new RegistrationEvent
            {
                EventId = e.Id,
                RegistrationId = registrationId
            });
        }

        /// <summary>
        /// Converts <see cref="SignUpToMarathonCommand"/> DTO to <see cref="Registration"/> entity and save it to registration repository
        /// </summary>
        private async Task<long> SignUpRunnerToMarathon(SignUpToMarathonCommand request, decimal eventsTotalCost, CancellationToken cancellationToken)
        {
            Registration runnerRegistration = await RegistrationProjection(request, eventsTotalCost, cancellationToken);

            _registrationRepository.Add(runnerRegistration);
            await _registrationRepository.SaveChangesAsync(cancellationToken);

            return runnerRegistration.Id;
        }

        /// <summary>
        /// Converts <see cref="SignUpToMarathonCommand"/> DTO to <see cref="Registration"/> entity
        /// </summary>
        private async Task<Registration> RegistrationProjection(SignUpToMarathonCommand request, decimal eventsTotalCost, CancellationToken cancellationToken)
        {
            return new Registration
            {
                RegisterDate = DateTime.UtcNow,
                SponsorshipTarget = request.SponsorshipTarget,
                RunnerId = request.RunnerId,
                CharityId = request.CharityId,
                RaceKitOptionId = request.RaceKitOptionId,
                RegistrationStatusId = await  GetInitialMarathonSignUpStatus(cancellationToken),
                Cost = await GetCostOfSelectedRaceKitOption(request.RaceKitOptionId, cancellationToken) + eventsTotalCost
            };
        }

        public async Task<decimal> GetCostOfSelectedRaceKitOption(long raceKitOptionId, CancellationToken cancellationToken)
        {
            return await _raceKitOptionCostHandler.Handle(new GetCostOfSelectedRaceKitOptionQuery(raceKitOptionId),
                cancellationToken);
        }

        private decimal GetEventsTotalCost(EventsListViewModel eventsListViewModel)
        {
            return eventsListViewModel.Events.Sum(e => e.Cost);
        }

        private async Task<long> GetInitialMarathonSignUpStatus(CancellationToken cancellationToken)
        {
            // TODO: Create enum for sign up status in domain layer
            return await _marathonSignUpStatusFinder.Handle(new SignUpStatusQuery("Registered"), cancellationToken);
        }

        #endregion
    }
}
