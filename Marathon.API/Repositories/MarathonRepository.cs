using System;
using System.Linq;
using Marathon.Persistence;
using Marathon.Domain.Entities;
using System.Collections.Generic;
using Marathon.API.Repositories.Interfaces;

namespace Marathon.API.Repositories
{
    using EventType = Models.Marathon.EventType;
    using MarathonSignUp = Models.Marathon.MarathonSignUp;
    using SignUpStatus = Domain.Enumerations.SignUpStatus;

    internal class MarathonRepository : IMarathonRepository
    {
        private readonly MarathonDbContext _context;

        public MarathonRepository(MarathonDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EventType> GetAllEventTypes()
        {
            var eventTypes = _context.EventTypes.ToArray();

            return eventTypes.Select(e => new EventType
            {
                Id = e.Id,
                Name = e.Name,
                Cost = GetActualCostOfCurrentEventType(e.Id)
            });
        }

        // TODO: Add race kit item stock count decrease
        public int SignUp(MarathonSignUp signUpCredentials)
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
                SignUpRunner(marathonSignUp);
            }
            catch
            {
                throw new Exception("Error has given when created a marathon sign up record");
            }


            try
            {
                SignUpRunnerToEvents(marathonSignUp.Id, GetEventsByEventType(signUpCredentials.EventTypeId));
            }
            catch
            {
                RemoveMarathonSignUp(marathonSignUp.Id);
                throw new Exception("Error has given when signed up runner to events");
            }

            return marathonSignUp.Id;
        }

        private void RemoveMarathonSignUp(int marathonSignUpId)
        {
            _context.MarathonSignUps.Remove(new Domain.Entities.MarathonSignUp { Id = marathonSignUpId });
            _context.SaveChanges();
        }

        private void SignUpRunnerToEvents(int marathonSignUpId, IEnumerable<Event> events)
        {
            _context.SignUpMarathonEvents.AddRange(events.Select(e => new SignUpMarathonEvent
            {
                SignUpId = marathonSignUpId,
                EventId = e.Id
            }));

            _context.SaveChanges();
        }

        // TODO: Add max participants check
        // TODO: Add start date condition
        private IEnumerable<Event> GetEventsByEventType(string eventTypeId)
        {
            return _context.Events.Where(e =>
                e.EventTypeId == eventTypeId && e.StartDate.HasValue);
        }

        private void SignUpRunner(Domain.Entities.MarathonSignUp marathonSignUp)
        {
            _context.Add(marathonSignUp);
            _context.SaveChanges();
        }

        // TODO: Add start date condition
        private decimal GetActualCostOfCurrentEventType(string eventTypeId)
        {
            Event actualEvent = _context.Events.FirstOrDefault(e => e.EventTypeId == eventTypeId);

            return actualEvent?.Cost ?? 0;
        }
    }
}
