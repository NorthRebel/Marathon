using System;
using System.Linq;
using Marathon.Persistence;
using System.Threading.Tasks;
using Marathon.Domain.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Marathon.API.Services
{
    using EventType = Models.Marathon.EventType;
    using SignUpStatus = Domain.Enumerations.SignUpStatus;
    using MarathonSignUp = Models.Marathon.MarathonSignUp;

    public class MarathonService : IMarathonService
    {
        private readonly MarathonDbContext _context;

        public MarathonService(MarathonDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventType>> GetEventTypes()
        {
            return await _context.EventTypes
                .Select(e => new EventType
                {
                    Id = e.Id,
                    Name = e.Name,
                    Cost = GetActualCostOfCurrentEventType(e.Id)
                })
                .ToArrayAsync();
        }

        public async Task<int> SignUp(MarathonSignUp signUpCredentials)
        {
            var marathonSignUp = new Domain.Entities.MarathonSignUp
            {
                RunnerId = signUpCredentials.RunnerId,
                SignUpDate = DateTime.UtcNow,
                RaceKitOptionId = signUpCredentials.RaceKitOptionId,
                SignUpStatusId = SignUpStatus.SignedUp.Id,
                Cost = signUpCredentials.Cost,
                CharityId = signUpCredentials.CharityId,
                SponsorshipTarget = signUpCredentials.SponsorshipTarget
            };

            try
            {
                SignUpRunner(marathonSignUp)
                    .Wait();
            }
            catch
            {
                throw new Exception("Error has given when created a marathon sign up record");
            }


            try
            {
                SignUpRunnerToEvents(marathonSignUp.Id, GetEventsByEventType(signUpCredentials.EventTypeId))
                    .Wait();
            }
            catch
            {
                await RemoveMarathonSignUp(marathonSignUp.Id).ContinueWith(x => throw new Exception("Error has given when signed up runner to events"));
            }

            return marathonSignUp.Id;
        }

        private Task RemoveMarathonSignUp(int marathonSignUpId)
        {
            _context.MarathonSignUps.Remove(new Domain.Entities.MarathonSignUp { Id = marathonSignUpId });
            return _context.SaveChangesAsync();
        }

        private Task SignUpRunnerToEvents(int marathonSignUpId, IEnumerable<Event> events)
        {
            _context.SignUpMarathonEvents.AddRange(events.Select(e => new SignUpMarathonEvent
            {
                SignUpId = marathonSignUpId,
                EventId = e.Id
            }));

            return _context.SaveChangesAsync();
        }

        // TODO: Add max participants check
        // TODO: Add start date condition
        private IEnumerable<Event> GetEventsByEventType(string eventTypeId)
        {
            return _context.Events.Where(e =>
                e.EventTypeId == eventTypeId && e.StartDate.HasValue);
        }

        private Task SignUpRunner(Domain.Entities.MarathonSignUp marathonSignUp)
        {
            _context.Add(marathonSignUp);
            return _context.SaveChangesAsync();
        }

        // TODO: Add start date condition
        private decimal GetActualCostOfCurrentEventType(string eventTypeId)
        {
            Event actualEvent = _context.Events.FirstOrDefault(e => e.EventTypeId == eventTypeId);

            return actualEvent?.Cost ?? 0;
        }
    }
}
