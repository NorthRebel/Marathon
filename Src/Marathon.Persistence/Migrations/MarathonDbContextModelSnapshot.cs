﻿// <auto-generated />
using System;
using Marathon.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Marathon.Persistence.Migrations
{
    [DbContext(typeof(MarathonDbContext))]
    partial class MarathonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Marathon.Domain.Entities.Charity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CharityId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("CharityDescription")
                        .HasMaxLength(2000);

                    b.Property<byte[]>("Logo")
                        .HasColumnName("CharityLogo");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("CharityName")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Charities");
                });

            modelBuilder.Entity("Marathon.Domain.Entities.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("CountryCode")
                        .HasColumnType("char(3)");

                    b.Property<byte[]>("Flag")
                        .IsRequired()
                        .HasColumnName("CountryFlag")
                        .HasColumnType("varbinary(max) ");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("CountryName")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Marathon.Domain.Entities.Event", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("EventId")
                        .HasColumnType("char(6)");

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("EventTypeId");

                    b.Property<byte>("MarathonId");

                    b.Property<short?>("MaxParticipants");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("EventName")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("StartDate")
                        .HasColumnName("StartDateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("MarathonId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Marathon.Domain.Entities.EventType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("EventTypeId")
                        .HasColumnType("char(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("EventTypes");
                });

            modelBuilder.Entity("Marathon.Domain.Entities.Gender", b =>
                {
                    b.Property<string>("Id")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnName("GenderId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("GenderName")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Marathon.Domain.Entities.Marathon", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnName("MarathonId");

                    b.Property<string>("City")
                        .HasMaxLength(80);

                    b.Property<string>("CountryId")
                        .HasColumnName("CountryCode")
                        .HasColumnType("char(3)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<short?>("YearHeld");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Marathons");
                });

            modelBuilder.Entity("Marathon.Domain.Entities.MarathonSignUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RegistrationId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharityId");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("RaceKitOptionId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<int>("RunnerId");

                    b.Property<DateTime>("SignUpDate")
                        .HasColumnType("datetime");

                    b.Property<byte>("SignUpStatusId")
                        .HasColumnName("RegistrationStatusId");

                    b.Property<decimal>("SponsorshipTarget")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("CharityId");

                    b.HasIndex("RaceKitOptionId");

                    b.HasIndex("RunnerId");

                    b.HasIndex("SignUpStatusId");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("Marathon.Domain.Entities.RaceKitItem", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RaceKitItemId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("RaceKitItems");
                });

            modelBuilder.Entity("Marathon.Domain.Entities.RaceKitOption", b =>
                {
                    b.Property<string>("Id")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnName("RaceKitOptionId");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("RaceKitOption")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("RaceKitOptions");
                });

            modelBuilder.Entity("Marathon.Domain.Entities.RaceKitOptionItem", b =>
                {
                    b.Property<short>("ItemId")
                        .HasColumnName("RaceKitItemId");

                    b.Property<string>("OptionId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnName("RaceKitOptionId");

                    b.HasKey("ItemId", "OptionId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("OptionId");

                    b.ToTable("RaceKitOptionItems");
                });

            modelBuilder.Entity("Marathon.Domain.Entities.Runner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RunnerId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryId")
                        .HasColumnName("CountryCode")
                        .HasColumnType("char(3)");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("GenderId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max) ");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("GenderId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Runners");
                });

            modelBuilder.Entity("Marathon.Domain.Entities.SignUpMarathonEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short?>("BibNumber");

                    b.Property<string>("EventId")
                        .HasColumnType("char(6)");

                    b.Property<int?>("RaceTime");

                    b.Property<int>("SignUpId")
                        .HasColumnName("RegistrationId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("SignUpId");

                    b.ToTable("RegistrationEvent");
                });

            modelBuilder.Entity("Marathon.Domain.Entities.SignUpStatus", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnName("RegistrationStatusId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("RegistrationStatus")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("RegistrationStatus");
                });

            modelBuilder.Entity("Marathon.Domain.Entities.Sponsorship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SponsorshipId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("SponsorName")
                        .HasMaxLength(150);

                    b.Property<int>("SignUpId")
                        .HasColumnName("RegistrationId");

                    b.HasKey("Id");

                    b.HasIndex("SignUpId");

                    b.ToTable("Sponsorships");
                });

            modelBuilder.Entity("Marathon.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .HasMaxLength(80);

                    b.Property<string>("LastName")
                        .HasMaxLength(80);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UserTypeId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Marathon.Domain.Entities.UserType", b =>
                {
                    b.Property<string>("Id")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnName("RoleId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("RoleName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Marathon.Domain.Entities.Volunteer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VolunteerId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryId")
                        .HasColumnName("CountryCode")
                        .HasColumnType("char(3)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(80);

                    b.Property<string>("GenderId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("LastName")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("GenderId");

                    b.ToTable("Volunteers");
                });

            modelBuilder.Entity("Marathon.Domain.Entities.Event", b =>
                {
                    b.HasOne("Marathon.Domain.Entities.EventType", "EventType")
                        .WithMany("Events")
                        .HasForeignKey("EventTypeId")
                        .HasConstraintName("FK_Events_EventTypes")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Marathon.Domain.Entities.Marathon", "Marathon")
                        .WithMany("Events")
                        .HasForeignKey("MarathonId")
                        .HasConstraintName("FK_Events_Marathons")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Marathon.Domain.Entities.Marathon", b =>
                {
                    b.HasOne("Marathon.Domain.Entities.Country", "Country")
                        .WithMany("Marathons")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK_Marathons_Countries")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Marathon.Domain.Entities.MarathonSignUp", b =>
                {
                    b.HasOne("Marathon.Domain.Entities.Charity", "Charity")
                        .WithMany("SignUps")
                        .HasForeignKey("CharityId")
                        .HasConstraintName("FK_Registrations_Charities")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Marathon.Domain.Entities.RaceKitOption", "RaceKitOption")
                        .WithMany("SignUps")
                        .HasForeignKey("RaceKitOptionId")
                        .HasConstraintName("FK_Registrations_RaceKitOptions")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Marathon.Domain.Entities.Runner", "Runner")
                        .WithMany("SignUps")
                        .HasForeignKey("RunnerId")
                        .HasConstraintName("FK_Registrations_Runners")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Marathon.Domain.Entities.SignUpStatus", "SignUpStatus")
                        .WithMany("SignUps")
                        .HasForeignKey("SignUpStatusId")
                        .HasConstraintName("FK_Registrations_RegistrationStatuses")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Marathon.Domain.Entities.RaceKitOptionItem", b =>
                {
                    b.HasOne("Marathon.Domain.Entities.RaceKitItem", "Item")
                        .WithMany("OptionItems")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK_OptionItems_Items")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Marathon.Domain.Entities.RaceKitOption", "Option")
                        .WithMany("OptionItems")
                        .HasForeignKey("OptionId")
                        .HasConstraintName("FK_OptionItems_Options")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Marathon.Domain.Entities.Runner", b =>
                {
                    b.HasOne("Marathon.Domain.Entities.Country", "Country")
                        .WithMany("Runners")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK_Runners_Countries")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Marathon.Domain.Entities.Gender", "Gender")
                        .WithMany("Runners")
                        .HasForeignKey("GenderId")
                        .HasConstraintName("FK_Runners_Genders")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Marathon.Domain.Entities.User", "User")
                        .WithOne("Runner")
                        .HasForeignKey("Marathon.Domain.Entities.Runner", "UserId")
                        .HasConstraintName("FK_User_Runner")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Marathon.Domain.Entities.SignUpMarathonEvent", b =>
                {
                    b.HasOne("Marathon.Domain.Entities.Event", "Event")
                        .WithMany("SignUpMarathonEvents")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_RegistrationEvents_Events")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Marathon.Domain.Entities.MarathonSignUp", "SignUp")
                        .WithMany("SignUpMarathonEvents")
                        .HasForeignKey("SignUpId")
                        .HasConstraintName("FK_RegistrationEvents_Registrations");
                });

            modelBuilder.Entity("Marathon.Domain.Entities.Sponsorship", b =>
                {
                    b.HasOne("Marathon.Domain.Entities.MarathonSignUp", "SignUp")
                        .WithMany("Sponsorships")
                        .HasForeignKey("SignUpId")
                        .HasConstraintName("FK_Sponsorships_Registrations")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Marathon.Domain.Entities.User", b =>
                {
                    b.HasOne("Marathon.Domain.Entities.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .HasConstraintName("FK_User_Roles")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Marathon.Domain.Entities.Volunteer", b =>
                {
                    b.HasOne("Marathon.Domain.Entities.Country", "Country")
                        .WithMany("Volunteers")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK_Volunteers_Countries")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Marathon.Domain.Entities.Gender", "Gender")
                        .WithMany("Volunteers")
                        .HasForeignKey("GenderId")
                        .HasConstraintName("FK_Volunteers_Genders")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
