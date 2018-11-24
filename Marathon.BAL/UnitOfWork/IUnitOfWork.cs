namespace Marathon.BAL.UnitOfWork
{
    using Repositories;
    using Domain.Entities;

    /// <summary>
    /// Contains all repositories of domain layer
    /// Source: https://medium.com/@utterbbq/c-unitofwork-and-repository-pattern-305cd8ecfa7a
    /// </summary>
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        /// <inheritdoc cref="UserType"/>
        IReadOnlyRepository<UserType> UserTypes { get; }

        /// <inheritdoc cref="User"/>
        IRepository<User> Users { get; }

        /// <inheritdoc cref="Runner"/>
        IRepository<Runner> Runners { get; }

        /// <inheritdoc cref="Gender"/>
        IReadOnlyRepository<Gender> Genders { get; }

        /// <inheritdoc cref="Volunteer"/>
        IRepository<Volunteer> Volunteers { get; }

        /// <inheritdoc cref="Country"/>
        IReadOnlyRepository<Country> Countries { get; }

        /// <inheritdoc cref="MarathonSignUp"/>
        IRepository<MarathonSignUp> MarathonSignUps { get; }

        /// <inheritdoc cref="SignUpStatus"/>
        IReadOnlyRepository<SignUpStatus> SignUpStatuses { get; }

        /// <inheritdoc cref="RaceKitOption"/>
        IRepository<RaceKitOption> RaceKitOptions { get; }

        /// <inheritdoc cref="RaceKitItem"/>
        IRepository<RaceKitItem> RaceKitItems { get; }

        /// <inheritdoc cref="RaceKitOptionItem"/>
        IRepository<RaceKitOptionItem> RaceKitOptionItems { get; }

        /// <inheritdoc cref="Charity"/>
        IRepository<Charity> Charities { get; }

        /// <inheritdoc cref="Sponsorship"/>
        IRepository<Sponsorship> Sponsorships { get; }

        /// <inheritdoc cref="SignUpMarathonEvent"/>
        IRepository<SignUpMarathonEvent> SignUpMarathonEvents { get; }

        /// <inheritdoc cref="Event"/>
        IRepository<Event> Events { get; }

        /// <inheritdoc cref="EventType"/>
        IReadOnlyRepository<EventType> EventTypes { get; }
        
        /// <inheritdoc cref="Marathon"/>
        IRepository<Marathon> Marathons { get; }
    }
}
