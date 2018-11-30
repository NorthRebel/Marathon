using Microsoft.EntityFrameworkCore;
using Marathon.Persistence.Extensions;

namespace Marathon.Persistence
{
    using Domain.Entities;

    /// <summary>
    /// Entity framework context 
    /// </summary>
    public sealed class MarathonDbContext : DbContext
    {
        #region Entities

        DbSet<UserType> UserTypes { get; set; }

        DbSet<User> Users { get; set; }

        DbSet<Runner> Runners { get; set; }

        DbSet<Gender> Genders { get; set; }

        DbSet<Volunteer> Volunteers { get; set; }

        DbSet<Country> Countries { get; set; }

        DbSet<MarathonSignUp> MarathonSignUps { get; set; }

        DbSet<SignUpStatus> SignUpStatuses { get; set; }

        DbSet<RaceKitOption> RaceKitOptions { get; set; }

        DbSet<RaceKitItem> RaceKitItems { get; set; }

        DbSet<RaceKitOptionItem> RaceKitOptionItems { get; set; }

        DbSet<Charity> Charities { get; set; }

        DbSet<Sponsorship> Sponsorships { get; set; }

        DbSet<SignUpMarathonEvent> SignUpMarathonEvents { get; set; }

        DbSet<Event> Events { get; set; }

        DbSet<EventType> EventTypes { get; set; }

        DbSet<Marathon> Marathons { get; set; }

        #endregion

        /// <summary>
        /// Constructor with context options to configure them
        /// </summary>
        /// <param name="options">Options for db context</param>
        public MarathonDbContext(DbContextOptions<MarathonDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
        }
    }
}
