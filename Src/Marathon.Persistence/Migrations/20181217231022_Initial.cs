using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marathon.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Charities",
                columns: table => new
                {
                    CharityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharityName = table.Column<string>(maxLength: 100, nullable: false),
                    CharityDescription = table.Column<string>(maxLength: 2000, nullable: true),
                    CharityLogo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charities", x => x.CharityId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryCode = table.Column<string>(type: "char(3)", nullable: false),
                    CountryName = table.Column<string>(maxLength: 100, nullable: false),
                    CountryFlag = table.Column<byte[]>(type: "varbinary(max) ", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryCode);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    EventTypeId = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.EventTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<string>(nullable: false),
                    GenderName = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "RaceKitItems",
                columns: table => new
                {
                    RaceKitItemId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceKitItems", x => x.RaceKitItemId);
                });

            migrationBuilder.CreateTable(
                name: "RaceKitOptions",
                columns: table => new
                {
                    RaceKitOptionId = table.Column<string>(nullable: false),
                    RaceKitOption = table.Column<string>(maxLength: 80, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceKitOptions", x => x.RaceKitOptionId);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationStatus",
                columns: table => new
                {
                    RegistrationStatusId = table.Column<byte>(nullable: false),
                    RegistrationStatus = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationStatus", x => x.RegistrationStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<string>(nullable: false),
                    RoleName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Marathons",
                columns: table => new
                {
                    MarathonId = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    City = table.Column<string>(maxLength: 80, nullable: true),
                    CountryCode = table.Column<string>(type: "char(3)", nullable: true),
                    YearHeld = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marathons", x => x.MarathonId);
                    table.ForeignKey(
                        name: "FK_Marathons_Countries",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    VolunteerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 80, nullable: true),
                    LastName = table.Column<string>(maxLength: 80, nullable: true),
                    CountryCode = table.Column<string>(type: "char(3)", nullable: true),
                    GenderId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.VolunteerId);
                    table.ForeignKey(
                        name: "FK_Volunteers_Countries",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Volunteers_Genders",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceKitOptionItems",
                columns: table => new
                {
                    RaceKitOptionId = table.Column<string>(nullable: false),
                    RaceKitItemId = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceKitOptionItems", x => new { x.RaceKitItemId, x.RaceKitOptionId })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_OptionItems_Items",
                        column: x => x.RaceKitItemId,
                        principalTable: "RaceKitItems",
                        principalColumn: "RaceKitItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptionItems_Options",
                        column: x => x.RaceKitOptionId,
                        principalTable: "RaceKitOptions",
                        principalColumn: "RaceKitOptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(maxLength: 80, nullable: true),
                    LastName = table.Column<string>(maxLength: 80, nullable: true),
                    UserTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Roles",
                        column: x => x.UserTypeId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<string>(type: "char(6)", nullable: false),
                    EventName = table.Column<string>(maxLength: 50, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    MaxParticipants = table.Column<short>(nullable: true),
                    MarathonId = table.Column<byte>(nullable: false),
                    EventTypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "EventTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Marathons",
                        column: x => x.MarathonId,
                        principalTable: "Marathons",
                        principalColumn: "MarathonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Runners",
                columns: table => new
                {
                    RunnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    GenderId = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    CountryCode = table.Column<string>(type: "char(3)", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max) ", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runners", x => x.RunnerId);
                    table.ForeignKey(
                        name: "FK_Runners_Countries",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Runners_Genders",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Runner",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SignUpDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SponsorshipTarget = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    RunnerId = table.Column<int>(nullable: false),
                    CharityId = table.Column<int>(nullable: false),
                    RaceKitOptionId = table.Column<string>(nullable: false),
                    RegistrationStatusId = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registrations_Charities",
                        column: x => x.CharityId,
                        principalTable: "Charities",
                        principalColumn: "CharityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_RaceKitOptions",
                        column: x => x.RaceKitOptionId,
                        principalTable: "RaceKitOptions",
                        principalColumn: "RaceKitOptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Runners",
                        column: x => x.RunnerId,
                        principalTable: "Runners",
                        principalColumn: "RunnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_RegistrationStatuses",
                        column: x => x.RegistrationStatusId,
                        principalTable: "RegistrationStatus",
                        principalColumn: "RegistrationStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BibNumber = table.Column<short>(nullable: true),
                    RaceTime = table.Column<int>(nullable: true),
                    EventId = table.Column<string>(type: "char(6)", nullable: true),
                    RegistrationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationEvents_Events",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistrationEvents_Registrations",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sponsorships",
                columns: table => new
                {
                    SponsorshipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SponsorName = table.Column<string>(maxLength: 150, nullable: false),
                    RegistrationId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsorships", x => x.SponsorshipId);
                    table.ForeignKey(
                        name: "FK_Sponsorships_Registrations",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                table: "Events",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_MarathonId",
                table: "Events",
                column: "MarathonId");

            migrationBuilder.CreateIndex(
                name: "IX_Marathons_CountryCode",
                table: "Marathons",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_RaceKitOptionItems_RaceKitOptionId",
                table: "RaceKitOptionItems",
                column: "RaceKitOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_CharityId",
                table: "Registration",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_RaceKitOptionId",
                table: "Registration",
                column: "RaceKitOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_RunnerId",
                table: "Registration",
                column: "RunnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_RegistrationStatusId",
                table: "Registration",
                column: "RegistrationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationEvent_EventId",
                table: "RegistrationEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationEvent_RegistrationId",
                table: "RegistrationEvent",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Runners_CountryCode",
                table: "Runners",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Runners_GenderId",
                table: "Runners",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Runners_UserId",
                table: "Runners",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sponsorships_RegistrationId",
                table: "Sponsorships",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_CountryCode",
                table: "Volunteers",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_GenderId",
                table: "Volunteers",
                column: "GenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceKitOptionItems");

            migrationBuilder.DropTable(
                name: "RegistrationEvent");

            migrationBuilder.DropTable(
                name: "Sponsorships");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "RaceKitItems");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "Marathons");

            migrationBuilder.DropTable(
                name: "Charities");

            migrationBuilder.DropTable(
                name: "RaceKitOptions");

            migrationBuilder.DropTable(
                name: "Runners");

            migrationBuilder.DropTable(
                name: "RegistrationStatus");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
