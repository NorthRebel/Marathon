using Xunit;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;
using Marathon.DAL.Repositories;
using System.Collections.Generic;
using Marathon.Tests.DAL.Extensions;
using Marathon.Application.Event.Exceptions;
using Marathon.Application.Tests.Extensions;
using Marathon.Application.Tests.Infrastructure;
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
    [Collection("Database collection")]
    public class SignUpToMarathonCommandHandlerTests
    {
        private readonly SignUpToMarathonCommandHandler _signUpToMarathonCommandHandler;

        private readonly IUnitOfWork _uow;

        public SignUpToMarathonCommandHandlerTests(DbContextFixture contextFixture)
        {
            IUnitOfWorkFactory uowFactory = new FixtureUoWFactory(contextFixture);

            _uow = uowFactory.Create();

            _uow.Initialize(async uow =>
            {
                ((IRepository<SignUpStatus>)uow.SignUpStatuses).ImportFromCollection(CreateMarathonSignUpStatuses());

                uow.RaceKitItems.ImportFromJson(@"Marathon\Data\RaceKitItem.json");
                uow.RaceKitOptions.ImportFromJson(@"Marathon\Data\RaceKitOption.json");
                uow.RaceKitOptionItems.ImportFromJson(@"Marathon\Data\RaceKitOptionItem.json");

                uow.Events.ImportFromJson(@"Marathon\Data\Event.json");
                uow.SignUpMarathonEvents.ImportFromJson(@"Marathon\Data\SignUpMarathonEvent.json");

                await uow.CommitAsync(CancellationToken.None);
            });

            #region Setup handlers

            var raceKitOptionAvailableQueryHandler = new IsRaceKitOptionAvailableQueryHandler(uowFactory);

            var costOfSelectedRaceKitOptionQueryHandler = new GetCostOfSelectedRaceKitOptionQueryHandler(uowFactory, raceKitOptionAvailableQueryHandler);

            var eventsByTypesQueryHandler = new GetEventsByTypesQueryHandler(uowFactory);

            var signUpStatusQueryHandler = new GetSignUpStatusQueryHandler(uowFactory);

            _signUpToMarathonCommandHandler = new SignUpToMarathonCommandHandler(uowFactory,
                                                                                 signUpStatusQueryHandler,
                                                                                 eventsByTypesQueryHandler,
                                                                                 costOfSelectedRaceKitOptionQueryHandler);

            #endregion
        }

        //private async Task SeedData()
        //{
        //    using (IUnitOfWork context = _uowFactory.Create())
        //    {
        //        ((IRepository<SignUpStatus>)context.SignUpStatuses).ImportFromCollection(CreateMarathonSignUpStatuses());

        //        context.RaceKitItems.ImportFromJson(@"Marathon\Data\RaceKitItem.json");
        //        context.RaceKitOptions.ImportFromJson(@"Marathon\Data\RaceKitOption.json");
        //        context.RaceKitOptionItems.ImportFromJson(@"Marathon\Data\RaceKitOptionItem.json");

        //        context.Events.ImportFromJson(@"Marathon\Data\Event.json");
        //        context.SignUpMarathonEvents.ImportFromJson(@"Marathon\Data\SignUpMarathonEvent.json");

        //        await context.CommitAsync(CancellationToken.None);
        //    }
        //}

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

            await Assert.ThrowsAsync<NoEventsOfSelectedTypesException>(async () => await _signUpToMarathonCommandHandler.Handle(request, CancellationToken.None));
        }

        [Theory]
        [JsonFileData(@"Marathon\Data\SignUpRequests.json", "Requests")]
        public async Task RunnerMustGetMarathonSignUpIdAfterSignUp(SignUpToMarathonCommand request)
        {
            // Act

            await _signUpToMarathonCommandHandler.Handle(request, CancellationToken.None);

            MarathonSignUp marathonSignUp = await _uow.MarathonSignUps.GetSingleAsync(ms => ms.RunnerId == request.RunnerId);

            // Assert

            Assert.NotEqual(default(long), marathonSignUp.Id);
        }

        [Theory]
        [JsonFileData(@"Marathon\Data\SignUpRequests.json", "Requests")]
        public async Task RunnerGetExceptionIfNotExistsRaceKitOption(SignUpToMarathonCommand request)
        {
            // Arrange

            var rnd = new Random();

            IEnumerable<RaceKitOption> raceKitOptions = await _uow.RaceKitOptions.GetAllAsync();
            request.RaceKitOptionId = rnd.Next((int)raceKitOptions.Max(i => i.Id), Int32.MaxValue);

            // Act-Assert

            await Assert.ThrowsAsync<RaceKitOptionNotExistsException>(async () => await _signUpToMarathonCommandHandler.Handle(request, CancellationToken.None));
        }

        [Theory]
        [JsonFileData(@"Marathon\Data\SignUpRequests.json", "Requests")]
        public async Task MarathonSignUpDateEqualsCurrent(SignUpToMarathonCommand request)
        {
            // Act

            await _signUpToMarathonCommandHandler.Handle(request, CancellationToken.None);

            MarathonSignUp marathonSignUp = await _uow.MarathonSignUps.GetSingleAsync(ms => ms.RunnerId == request.RunnerId);

            // Assert

            Assert.Equal(DateTime.UtcNow.Date, marathonSignUp.SignUpDate.Date);
        }

        [Theory]
        [JsonFileData(@"Marathon\Data\SignUpRequests.json", "Requests")]
        public async Task BibNumberMustBeNull(SignUpToMarathonCommand request)
        {
            // Act

            await _signUpToMarathonCommandHandler.Handle(request, CancellationToken.None);

            MarathonSignUp marathonSignUp = await _uow.MarathonSignUps.GetSingleAsync(ms => ms.RunnerId == request.RunnerId);
            SignUpMarathonEvent signUpMarathonEvent = await _uow.SignUpMarathonEvents.GetSingleAsync(sm => sm.SignUpId == marathonSignUp.Id);

            // Assert

            Assert.Null(signUpMarathonEvent.BibNumber);
        }

        [Theory]
        [JsonFileData(@"Marathon\Data\SignUpRequests.json", "Requests")]
        public async Task RaceTimeMustBeNull(SignUpToMarathonCommand request)
        {
            // Act

            await _signUpToMarathonCommandHandler.Handle(request, CancellationToken.None);

            MarathonSignUp marathonSignUp = await _uow.MarathonSignUps.GetSingleAsync(ms => ms.RunnerId == request.RunnerId);
            SignUpMarathonEvent signUpMarathonEvent = await _uow.SignUpMarathonEvents.GetSingleAsync(sm => sm.SignUpId == marathonSignUp.Id);

            // Assert

            Assert.Null(signUpMarathonEvent.RaceTime);
        }

        [Theory]
        [JsonFileData(@"Marathon\Data\SignUpRequests.json", "Requests")]
        public async Task SignUpStatusEqualSignedUp(SignUpToMarathonCommand request)
        {
            // Act

            await _signUpToMarathonCommandHandler.Handle(request, CancellationToken.None);

            MarathonSignUp marathonSignUp = await _uow.MarathonSignUps.GetSingleAsync(ms => ms.RunnerId == request.RunnerId);

            // Assert

            Assert.Equal(SignUpStatusEnum.SignedUp.Id, marathonSignUp.SignUpStatusId);
        }
    }
}
