using Xunit;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.Repositories;
using System.Collections.Generic;
using Marathon.Tests.DAL.Extensions;
using Marathon.Tests.DAL.Infrastructure;
using Marathon.Application.Event.Exceptions;
using Marathon.Application.Tests.Extensions;
using Marathon.Application.RaceKitOption.Exceptions;
using Marathon.Application.Event.Queries.GetEventsByTypes;
using Marathon.Application.Marathon.Queries.GetSignUpStatus;
using Marathon.Application.Marathon.Commands.SignUpToMarathon;
using SignUpStatusEnum = Marathon.Domain.Enumerations.SignUpStatus;
using Marathon.Application.RaceKitOption.Queries.IsRaceKitOptionAvailable;
using Marathon.Application.RaceKitOption.Queries.GetCostOfSelectedRaceKitOption;

namespace Marathon.Application.Tests.Marathon.Handlers
{
    using Domain.Entities;

    /// <summary>
    /// Unit test module for <see cref="SignUpToMarathonCommandHandler"/>
    /// </summary>
    public class SignUpToMarathonCommandHandlerTests : IClassFixture<UnitOfWorkFixture>
    {
        private readonly UnitOfWorkFixture _unitOfWork;
        private readonly SignUpToMarathonCommandHandler _signUpToMarathonCommandHandler;

        public SignUpToMarathonCommandHandlerTests(UnitOfWorkFixture unitOfWorkFixture)
        {
            _unitOfWork = unitOfWorkFixture;

            _unitOfWork.Context.Initialize(async uow =>
            {
                uow.RaceKitItems.ImportFromJson(@"Marathon\Data\RaceKitItem.json");
                uow.RaceKitOptions.ImportFromJson(@"Marathon\Data\RaceKitOption.json");
                uow.RaceKitOptionItems.ImportFromJson(@"Marathon\Data\RaceKitOptionItem.json");

                uow.Events.ImportFromJson(@"Marathon\Data\Event.json");
                uow.SignUpMarathonEvents.ImportFromJson(@"Marathon\Data\SignUpMarathonEvent.json");

                await uow.CommitAsync(CancellationToken.None);
            });

            #region Setup handlers

            var raceKitOptionAvailableQueryHandler = new IsRaceKitOptionAvailableQueryHandler(_unitOfWork.ContextFactory);

            var costOfSelectedRaceKitOptionQueryHandler = new GetCostOfSelectedRaceKitOptionQueryHandler(_unitOfWork.ContextFactory, raceKitOptionAvailableQueryHandler);

            var eventsByTypesQueryHandler = new GetEventsByTypesQueryHandler(_unitOfWork.ContextFactory);

            var signUpStatusQueryHandler = new GetSignUpStatusQueryHandler(_unitOfWork.ContextFactory);

            _signUpToMarathonCommandHandler = new SignUpToMarathonCommandHandler(_unitOfWork.ContextFactory,
                                                                                 signUpStatusQueryHandler,
                                                                                 eventsByTypesQueryHandler,
                                                                                 costOfSelectedRaceKitOptionQueryHandler);

            #endregion
        }

        [Fact]
        public async Task RunnerGetExceptionIfNoEventsOfSelectedTypes()
        {
            // Arrange

            var request = new SignUpToMarathonCommand
            {
                RunnerId = 242,
                RaceKitOptionId ='A',
                CharityId = 12,
                SponsorshipTarget = 500m,
                EventTypeIds = new[] { "AA", "BB", "CC" }
            };

            // Act-Assert

            await Assert.ThrowsAsync<NoEventsOfSelectedTypesException>(async () => await _signUpToMarathonCommandHandler.Handle(request, CancellationToken.None));
        }

        [Theory]
        [JsonFileData(@"Marathon\Data\SignUpRequests.json", "Requests")]
        public async Task RunnerMustGetMarathonSignUpIdAfterSignUp(SignUpToMarathonCommand request)
        {
            // Act

            await _signUpToMarathonCommandHandler.Handle(request, CancellationToken.None);

            MarathonSignUp marathonSignUp = await _unitOfWork.Context.MarathonSignUps.GetSingleAsync(ms => ms.RunnerId == request.RunnerId);

            // Assert

            Assert.NotEqual(default(long), marathonSignUp.Id);
        }

        [Theory]
        [JsonFileData(@"Marathon\Data\SignUpRequests.json", "Requests")]
        public async Task RunnerGetExceptionIfNotExistsRaceKitOption(SignUpToMarathonCommand request)
        {
            // Arrange

            request.RaceKitOptionId = 'D';

            // Act-Assert

            await Assert.ThrowsAsync<RaceKitOptionNotExistsException>(async () => await _signUpToMarathonCommandHandler.Handle(request, CancellationToken.None));
        }

        [Theory]
        [JsonFileData(@"Marathon\Data\SignUpRequests.json", "Requests")]
        public async Task MarathonSignUpDateEqualsCurrent(SignUpToMarathonCommand request)
        {
            // Act

            await _signUpToMarathonCommandHandler.Handle(request, CancellationToken.None);

            MarathonSignUp marathonSignUp = await _unitOfWork.Context.MarathonSignUps.GetSingleAsync(ms => ms.RunnerId == request.RunnerId);

            // Assert

            Assert.Equal(DateTime.UtcNow.Date, marathonSignUp.SignUpDate.Date);
        }

        [Theory]
        [JsonFileData(@"Marathon\Data\SignUpRequests.json", "Requests")]
        public async Task BibNumberMustBeNull(SignUpToMarathonCommand request)
        {
            // Act

            await _signUpToMarathonCommandHandler.Handle(request, CancellationToken.None);

            MarathonSignUp marathonSignUp = await _unitOfWork.Context.MarathonSignUps.GetSingleAsync(ms => ms.RunnerId == request.RunnerId);
            SignUpMarathonEvent signUpMarathonEvent = await _unitOfWork.Context.SignUpMarathonEvents.GetSingleAsync(sm => sm.SignUpId == marathonSignUp.Id);

            // Assert

            Assert.Null(signUpMarathonEvent.BibNumber);
        }

        [Theory]
        [JsonFileData(@"Marathon\Data\SignUpRequests.json", "Requests")]
        public async Task RaceTimeMustBeNull(SignUpToMarathonCommand request)
        {
            // Act

            await _signUpToMarathonCommandHandler.Handle(request, CancellationToken.None);

            MarathonSignUp marathonSignUp = await _unitOfWork.Context.MarathonSignUps.GetSingleAsync(ms => ms.RunnerId == request.RunnerId);
            SignUpMarathonEvent signUpMarathonEvent = await _unitOfWork.Context.SignUpMarathonEvents.GetSingleAsync(sm => sm.SignUpId == marathonSignUp.Id);

            // Assert

            Assert.Null(signUpMarathonEvent.RaceTime);
        }

        [Theory]
        [JsonFileData(@"Marathon\Data\SignUpRequests.json", "Requests")]
        public async Task SignUpStatusEqualSignedUp(SignUpToMarathonCommand request)
        {
            // Act

            await _signUpToMarathonCommandHandler.Handle(request, CancellationToken.None);

            MarathonSignUp marathonSignUp = await _unitOfWork.Context.MarathonSignUps.GetSingleAsync(ms => ms.RunnerId == request.RunnerId);

            // Assert

            Assert.Equal(SignUpStatusEnum.SignedUp.Id, marathonSignUp.SignUpStatusId);
        }
    }
}
