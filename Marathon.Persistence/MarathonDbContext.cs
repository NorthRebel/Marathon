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

        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Runner> Runners { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Volunteer> Volunteers { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<MarathonSignUp> MarathonSignUps { get; set; }

        public DbSet<SignUpStatus> SignUpStatuses { get; set; }

        public DbSet<RaceKitOption> RaceKitOptions { get; set; }

        public DbSet<RaceKitItem> RaceKitItems { get; set; }

        public DbSet<RaceKitOptionItem> RaceKitOptionItems { get; set; }

        public DbSet<Charity> Charities { get; set; }

        public DbSet<Sponsorship> Sponsorships { get; set; }

        public DbSet<SignUpMarathonEvent> SignUpMarathonEvents { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventType> EventTypes { get; set; }

        public DbSet<Marathon> Marathons { get; set; }

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
