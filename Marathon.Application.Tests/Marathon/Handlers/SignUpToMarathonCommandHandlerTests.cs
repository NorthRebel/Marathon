﻿using Moq;
using Xunit;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Marathon.Application.Event.Exceptions;
using Marathon.Application.Tests.Extensions;
using EventModel = Marathon.Domain.Entities.Event;
using Marathon.Application.Event.Queries.GetEventsByTypes;
using Marathon.Application.Marathon.Queries.GetSignUpStatus;
using Marathon.Application.Tests.Infrastructure.Repositories;
using Marathon.Application.Marathon.Commands.SignUpToMarathon;
using Marathon.Application.RaceKitOption.Exceptions;
using SignUpStatusEnum = Marathon.Domain.Enumerations.SignUpStatus;
using Marathon.Application.Tests.Infrastructure.Repositories.BaseEntity;
using Marathon.Application.RaceKitOption.Queries.IsRaceKitOptionAvailable;
using Marathon.Application.RaceKitOption.Queries.GetCostOfSelectedRaceKitOption;

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
        private readonly BaseReadOnlyRepositoryMock<RaceKitOptionItem> _optionItemRepository;

        #endregion

        #endregion

        private readonly CancellationToken _cancellationToken;

        public SignUpToMarathonCommandHandlerTests()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            _cancellationToken = cancelTokenSource.Token;

            #region Mock repositories

            _raceKitItemRepository = (ReadOnlyRepositoryMock<RaceKitItem>)new ReadOnlyRepositoryMock<RaceKitItem>()
                .FromJson(@"Marathon\Data\RaceKitItem.json");

            _optionItemRepository = (BaseReadOnlyRepositoryMock<RaceKitOptionItem>)new BaseReadOnlyRepositoryMock<RaceKitOptionItem>()
                .FromJson(@"Marathon\Data\RaceKitOptionItem.json");

            _raceKitOptionRepository = (ReadOnlyRepositoryMock<RaceKitOption>)new ReadOnlyRepositoryMock<RaceKitOption>()
                .FromJson(@"Marathon\Data\RaceKitOption.json");

            _eventRepository = (ReadOnlyRepositoryMock<EventModel>)new ReadOnlyRepositoryMock<EventModel>()
                .FromJson(@"Marathon\Data\Event.json");

            _signUpMarathonEventReadRepository = (ReadOnlyRepositoryMock<SignUpMarathonEvent>)new ReadOnlyRepositoryMock<SignUpMarathonEvent>()
                .FromJson(@"Marathon\Data\SignUpMarathonEvent.json");

            _signUpStatusRepository = (ReadOnlyRepositoryMock<SignUpStatus>)new ReadOnlyRepositoryMock<SignUpStatus>()
                .FromCollection(CreateMarathonSignUpStatuses());

            _marathonSignUpRepository = new RepositoryMock<MarathonSignUp>();

            _signUpMarathonEventWriteRepository = new RepositoryMock<SignUpMarathonEvent>();

            #endregion

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

        private IEnumerable<SignUpStatus> CreateMarathonSignUpStatuses()
        {
            foreach (var signUpStatus in SignUpStatusEnum.GetAll<SignUpStatusEnum>())
            {
                yield return new SignUpStatus
                {
                    Id = signUpStatus.Id,
                    Name = signUpStatus.Name
                };
            }
        }
        
        // TODO: Add repositories verification test

        [Fact]
        public async Task RunnerGetExceptionIfNoEventsOfSelectedTypes()
        {
            // Arrange

            var request = new SignUpToMarathonCommand
            {
                RunnerId = 242,
                RaceKitOptionId = 2,
                CharityId = 12,
                SponsorshipTarget = 500m,
                EventTypeIds = new long[] { 20, 40, 50 }
            };

            // Act-Assert

            await Assert.ThrowsAsync<NoEventsOfSelectedTypesException>(async () => await _signUpToMarathonCommandHandler.Handle(request, _cancellationToken));
        }

        [Theory]
        [JsonFileData(@"Marathon\Data\SignUpRequests.json", "Requests")]
        public async Task RunnerMustGetMarathonSignUpIdAfterSignUp(SignUpToMarathonCommand request)
        {
            // Act

            await _signUpToMarathonCommandHandler.Handle(request, _cancellationToken);

            // Assert

            long id = _marathonSignUpRepository.Items.Find(s => s.RunnerId == request.RunnerId).Id;
            Assert.NotEqual(default(long), id);
        }

        [Theory]
        [JsonFileData(@"Marathon\Data\SignUpRequests.json", "Requests")]
        public async Task RunnerGetExceptionIfNotExistsRaceKitOption(SignUpToMarathonCommand request)
        {
            // Arrange

            var rnd = new Random();

            request.RaceKitOptionId = rnd.Next((int) _raceKitOptionRepository.Items.Max(i => i.Id), Int32.MaxValue);

            // Act-Assert

            await Assert.ThrowsAsync<RaceKitOptionNotExistsException>(async () => await _signUpToMarathonCommandHandler.Handle(request, _cancellationToken));
        }

        [Theory]
        [JsonFileData(@"Marathon\Data\SignUpRequests.json", "Requests")]
        public async Task MarathonSignUpDateEqualsCurrent(SignUpToMarathonCommand request)
        {
            // Act

            await _signUpToMarathonCommandHandler.Handle(request, _cancellationToken);

            // Assert

            DateTime signUpDate = _marathonSignUpRepository.Items.Find(s => s.RunnerId == request.RunnerId).SignUpDate;
            Assert.Equal(DateTime.UtcNow.Date, signUpDate.Date);
        }

        [Theory]
        [JsonFileData(@"Marathon\Data\SignUpRequests.json", "Requests")]
        public async Task BibNumberMustBeNull(SignUpToMarathonCommand request)
        {
            // Act

            await _signUpToMarathonCommandHandler.Handle(request, _cancellationToken);

            // Assert

            long signUpId = _marathonSignUpRepository.Items.Find(s => s.RunnerId == request.RunnerId).Id;
            short? bibNumber = _signUpMarathonEventWriteRepository.Items.Find(s => s.SignUpId == signUpId).BibNumber;

            Assert.Null(bibNumber);
        }

        [Theory]
        [JsonFileData(@"Marathon\Data\SignUpRequests.json", "Requests")]
        public async Task RaceTimeMustBeNull(SignUpToMarathonCommand request)
        {
            // Act

            await _signUpToMarathonCommandHandler.Handle(request, _cancellationToken);

            // Assert

            long signUpId = _marathonSignUpRepository.Items.Find(s => s.RunnerId == request.RunnerId).Id;
            long? raceTime = _signUpMarathonEventWriteRepository.Items.Find(s => s.SignUpId == signUpId).RaceTime;

            Assert.Null(raceTime);
        }

        [Theory]
        [JsonFileData(@"Marathon\Data\SignUpRequests.json", "Requests")]
        public async Task SignUpStatusEqualSignedUp(SignUpToMarathonCommand request)
        {
            // Act

            await _signUpToMarathonCommandHandler.Handle(request, _cancellationToken);

            // Assert

            long signUpStatusId = _marathonSignUpRepository.Items.Find(s => s.RunnerId == request.RunnerId).SignUpStatusId;

            Assert.Equal(Domain.Enumerations.SignUpStatus.SignedUp.Id, signUpStatusId);
        }
    }
}