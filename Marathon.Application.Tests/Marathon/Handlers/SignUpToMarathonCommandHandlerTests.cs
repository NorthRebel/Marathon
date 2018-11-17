using System.Threading;
using Marathon.Application.Event.Queries.GetEventsByTypes;
using Marathon.Application.Marathon.Commands.SignUpToMarathon;
using Marathon.Application.Marathon.Queries.GetSignUpStatus;
using Marathon.Application.RaceKitOption.Queries.GetCostOfSelectedRaceKitOption;
using Marathon.Application.RaceKitOption.Queries.IsRaceKitOptionAvailable;
using Marathon.Application.Tests.Infrastructure.Repositories;
using Marathon.Application.Tests.Infrastructure.Repositories.BaseEntity;
using EventModel = Marathon.Domain.Entities.Event;

namespace Marathon.Application.Tests.Marathon.Handlers
{
    using Domain.Entities;

    /// <summary>
    /// Unit test module for <see cref="SignUpToMarathonCommandHandler"/>
    /// </summary>
    public class SignUpToMarathonCommandHandlerTests
    {
        #region Main handler

        private readonly SignUpToMarathonCommandHandler _signUpToMarathonCommandHandler;

        private readonly RepositoryMock<MarathonSignUp> _marathonSignUpRepository;
        private readonly RepositoryMock<SignUpMarathonEvent> _signUpMarathonEventWriteRepository;

        #endregion

        #region GetSignUpStatus

        private readonly GetSignUpStatusQueryHandler _signUpStatusQueryHandler;

        private readonly ReadOnlyRepositoryMock<SignUpStatus> _signUpStatusRepository;

        #endregion

        #region GetEventsByTypes

        private readonly GetEventsByTypesQueryHandler _eventsByTypesQueryHandler;

        private readonly ReadOnlyRepositoryMock<EventModel> _eventRepository;
        private readonly ReadOnlyRepositoryMock<SignUpMarathonEvent> _signUpMarathonEventReadRepository;

        #endregion

        #region GetCostOfSelectedRaceKitOption

        private readonly GetCostOfSelectedRaceKitOptionQueryHandler _costOfSelectedRaceKitOptionQueryHandler;

        private readonly ReadOnlyRepositoryMock<RaceKitOption> _raceKitOptionRepository;

        #region IsRaceKitOptionAvailable

        private readonly IsRaceKitOptionAvailableQueryHandler _raceKitOptionAvailableQueryHandler;

        private readonly ReadOnlyRepositoryMock<RaceKitItem> _raceKitItemRepository;
        private readonly BaseRepositoryMock<RaceKitOptionItem> _optionItemRepository;

        #endregion

        #endregion

        private readonly CancellationToken _cancellationToken;

        public SignUpToMarathonCommandHandlerTests()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            _cancellationToken = cancelTokenSource.Token;

            #region Setup handlers

            _raceKitOptionAvailableQueryHandler = new IsRaceKitOptionAvailableQueryHandler(_raceKitItemRepository.Object,
                                                                                           _optionItemRepository.Object);

            _costOfSelectedRaceKitOptionQueryHandler = new GetCostOfSelectedRaceKitOptionQueryHandler(_raceKitOptionRepository.Object, 
                                                                                                      _raceKitOptionAvailableQueryHandler);

            _eventsByTypesQueryHandler = new GetEventsByTypesQueryHandler(_eventRepository.Object, 
                                                                          _signUpMarathonEventReadRepository.Object);

            _signUpStatusQueryHandler = new GetSignUpStatusQueryHandler(_signUpStatusRepository.Object);

            _signUpToMarathonCommandHandler = new SignUpToMarathonCommandHandler(_marathonSignUpRepository.Object,
                                                                                 _signUpMarathonEventWriteRepository.Object, 
                                                                                 _signUpStatusQueryHandler, 
                                                                                 _eventsByTypesQueryHandler,
                                                                                 _costOfSelectedRaceKitOptionQueryHandler);

            #endregion
        }
    }
}
