using Polly;
using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Marathon.Domain.Common;
using Marathon.Domain.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Marathon.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Marathon.Persistence.Extensions;

namespace Marathon.Persistence.Seed
{
    using Gender = Domain.Entities.Gender;
    using UserType = Domain.Entities.UserType;
    using SignUpStatus = Domain.Entities.SignUpStatus;
    using GenderEnum = Domain.Enumerations.Gender;
    using UserTypeEnum = Domain.Enumerations.UserType;
    using SignUpStatusEnum = Domain.Enumerations.SignUpStatus;

    /// <summary>
    /// Initialize entities of <see cref="MarathonDbContext"/>
    /// </summary>
    public class ContextInitializer
    {
        private const string SetupFolder = "Setup";
        
        public async Task SeedAsync(MarathonDbContext context, IHostingEnvironment env, ILogger<ContextInitializer> logger)
        {
            // Policy to catch exceptions on bulk operation
            var policy = CreatePolicy(logger, nameof(ContextInitializer));

            await policy.ExecuteAsync(async () =>
            {

                // Absolute path to source files
                var contentRootPath = env.ContentRootPath;

                if (!context.UserTypes.Any())
                {
                    SeedUserTypes(context);
                    await context.SaveChangesAsync();
                }


                if (!context.Genders.Any())
                {
                    SeedGenders(context);
                    await context.SaveChangesAsync();
                }

                if (!context.SignUpStatuses.Any())
                {
                    SeedSignUpStatuses(context);
                    await context.SaveChangesAsync();
                }

                if (!context.Countries.Any())
                {
                    await context.Countries.AddRangeAsync(GetCountriesFromFile(contentRootPath, logger));
                    await context.SaveChangesAsync();
                }

                if (!context.Marathons.Any())
                {
                    await context.Marathons.AddRangeAsync(GetMarathonsFromFile(contentRootPath, context, logger));
                    await context.SaveChangesAsync();
                }

                if (!context.EventTypes.Any())
                {
                    await context.EventTypes.AddRangeAsync(GetEventTypesFromFile(contentRootPath, logger));
                    await context.SaveChangesAsync();
                }

                if (context.Events.Any())
                {
                    await context.Events.AddRangeAsync(GetEventsFromFile(contentRootPath, context, logger));
                    await context.SaveChangesAsync();
                }

                if (!context.Users.Any())
                {
                    await context.Users.AddRangeAsync(GetUsersFromFile(contentRootPath, context, logger));
                    await context.SaveChangesAsync();
                }

                if (!context.Volunteers.Any())
                {
                    await context.Volunteers.AddRangeAsync(GetVolunteersFromFile(contentRootPath, context, logger));
                    await context.SaveChangesAsync();
                }

                if (!context.Runners.Any())
                {
                    await context.Runners.AddRangeAsync(GetRunnersFromFile(contentRootPath, context, logger));
                    await context.SaveChangesAsync();
                }

                if (!context.Charities.Any())
                {
                    await context.Charities.AddRangeAsync(GetCharitiesFromFile(contentRootPath, logger));
                    await context.SaveChangesAsync();
                }

                if (!context.RaceKitOptions.Any())
                {
                    await context.RaceKitOptions.AddRangeAsync(GetRaceKitOptionsFromFile(contentRootPath, logger));
                    await context.SaveChangesAsync();
                }

                if (!context.RaceKitItems.Any())
                {
                    await context.RaceKitItems.AddRangeAsync(GetRaceKitItemsFromFile(contentRootPath, logger));
                    await context.SaveChangesAsync();
                }

                if (!context.RaceKitOptionItems.Any())
                {
                    await context.RaceKitOptionItems.AddRangeAsync(GetOptionItemsFromFile(contentRootPath, context, logger));
                    await context.SaveChangesAsync();
                }

                if (!context.MarathonSignUps.Any())
                {
                    await context.MarathonSignUps.AddRangeAsync(GetMarathonSignUpsFromFile(contentRootPath, context, logger));
                    await context.SaveChangesAsync();
                }

                if (!context.Sponsorships.Any())
                {
                    await context.Sponsorships.AddRangeAsync(GetSponsorshipsFromFile(contentRootPath, context, logger));
                    await context.SaveChangesAsync();
                }

                if (!context.SignUpMarathonEvents.Any())
                {
                    await context.SignUpMarathonEvents.AddRangeAsync(GetSignUpMarathonEventsFromFile(contentRootPath, context, logger));
                    await context.SaveChangesAsync();
                }
            });
        }

        #region Initialize linked enumerations

        public void SeedUserTypes(MarathonDbContext context)
        {
            SeedEnumeration<UserType, char, UserTypeEnum>(context.UserTypes, UserTypeEnum.GetAll<UserTypeEnum>());
        }

        public void SeedGenders(MarathonDbContext context)
        {
            SeedEnumeration<Gender, char, GenderEnum>(context.Genders, GenderEnum.GetAll<GenderEnum>());
        }

        public void SeedSignUpStatuses(MarathonDbContext context)
        {
            SeedEnumeration<SignUpStatus, byte, SignUpStatusEnum>(context.SignUpStatuses, SignUpStatusEnum.GetAll<SignUpStatusEnum>());
        }

        #endregion

        #region Initialize from CSV

        #region Countries

        // TODO: Get image from zip archive
        public IEnumerable<Country> GetCountriesFromFile(string contentRootPath, ILogger<ContextInitializer> logger)
        {
            string csvCountriesFile = Path.Combine(contentRootPath, SetupFolder, "Countries.csv");

            string[] csvHeaders;
            try
            {
                string[] requiredHeaders = { "Id", "Name" };
                csvHeaders = CheckFileHeader(csvCountriesFile, requiredHeaders);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new Country[0];
            }

            return File.ReadAllLines(csvCountriesFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateCountry(column, csvHeaders))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private Country CreateCountry(string[] columns, string[] headers)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            #region Check required fields

            #region Primary key

            string id = columns[Array.IndexOf(headers, "Id")].TrimQuotes();
            if (string.IsNullOrWhiteSpace(id))
                throw new Exception($"Id '{id}' isn't a valid identity key");

            #endregion

            #region Name

            string name = columns[Array.IndexOf(headers, "Name")].TrimQuotes();
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name column is empty");

            #endregion

            #endregion

            var country = new Country
            {
                Id = id,
                Name = name
            };

            return country;
        }

        #endregion

        #region Users

        public IEnumerable<User> GetUsersFromFile(string contentRootPath, MarathonDbContext context, ILogger<ContextInitializer> logger)
        {
            string csvUsersFile = Path.Combine(contentRootPath, SetupFolder, "Users.csv");

            string[] csvHeaders;
            try
            {
                string[] requiredHeaders = { "Id", "Email", "Password", "UserTypeId" };
                string[] optionalHeaders = { "FirstName", "LastName" };
                csvHeaders = CheckFileHeader(csvUsersFile, requiredHeaders, optionalHeaders);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new User[0];
            }

            // Get keys from dependency sets
            IEnumerable<char> userTypeIds = context.UserTypes.GetKeysFromSet<UserType, char>();

            return File.ReadAllLines(csvUsersFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateUser(column, csvHeaders, userTypeIds))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private User CreateUser(string[] columns, string[] headers, IEnumerable<char> userTypeIds)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            if (userTypeIds == null)
                throw new ArgumentNullException(nameof(userTypeIds));

            #region Check required fields

            #region Primary key

            string idStr = columns[Array.IndexOf(headers, "Id")].TrimQuotes();
            if (!uint.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity number");

            #endregion

            #region Email

            string email = columns[Array.IndexOf(headers, "Email")].TrimQuotes();
            if (!IsValidEmail(email))
                throw new Exception($"Email string '{email}' isn't valid");

            #endregion

            #region Password

            // TODO: Add password regex check
            string password = columns[Array.IndexOf(headers, "Password")].TrimQuotes();
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password column is empty!");

            #endregion

            #region UserTypeId

            string userTypeStr = columns[Array.IndexOf(headers, "UserTypeId")].TrimQuotes();
            if (!char.TryParse(userTypeStr, out var userTypeId))
                throw new Exception($"User type '{userTypeStr}' isn't valid");

            if (!userTypeIds.Contains(userTypeId))
                throw new Exception($"User type '{userTypeId}' doesn't exist in dependent set");

            #endregion

            #endregion

            var user = new User
            {
                Id = id,
                Email = email,
                Password = password,
                UserTypeId = userTypeId
            };

            #region Check optional fields

            #region First name

            int firstNameIndex = Array.IndexOf(headers, "FirstName");
            if (firstNameIndex > -1)
            {
                string firstName = columns[firstNameIndex].TrimQuotes();

                user.FirstName = !string.IsNullOrWhiteSpace(firstName)
                    ? firstName
                    : throw new Exception("FirstName column in empty");
            }

            #endregion

            #region Last name

            int lastNameIndex = Array.IndexOf(headers, "LastName");
            if (lastNameIndex > -1)
            {
                string lastName = columns[lastNameIndex].TrimQuotes();

                user.LastName = !string.IsNullOrEmpty(lastName)
                    ? lastName
                    : throw new Exception("LastName column is empty!");
            }

            #endregion

            #endregion

            return user;
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Runners

        public IEnumerable<Runner> GetRunnersFromFile(string contentRootPath, MarathonDbContext context, ILogger<ContextInitializer> logger)
        {
            string csvRunnersFile = Path.Combine(contentRootPath, SetupFolder, "Runners.csv");

            string[] csvHeaders;
            try
            {
                string[] requiredHeaders = { "Id", "UserId", "GenderId", "CountryId" };
                string[] optionalHeaders = { "DateOfBirth" };
                csvHeaders = CheckFileHeader(csvRunnersFile, requiredHeaders, optionalHeaders);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new Runner[0];
            }

            // Get keys from dependency sets
            IEnumerable<uint> userIds = context.Users.GetKeysFromSet<User, uint>();
            IEnumerable<char> genderIds = context.Genders.GetKeysFromSet<Gender, char>();
            IEnumerable<string> countryIds = context.Countries.GetKeysFromSet<Country, string>();

            return File.ReadAllLines(csvRunnersFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateRunner(column, csvHeaders, userIds, genderIds, countryIds))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private Runner CreateRunner(string[] columns, string[] headers, IEnumerable<uint> userIds, IEnumerable<char> genderIds, IEnumerable<string> countryIds)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            if (userIds == null)
                throw new ArgumentNullException(nameof(userIds));

            if (genderIds == null)
                throw new ArgumentNullException(nameof(genderIds));

            if (countryIds == null)
                throw new ArgumentNullException(nameof(countryIds));

            #region Check required fields

            #region Primary key

            string idStr = columns[Array.IndexOf(headers, "Id")].TrimQuotes();
            if (!uint.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity number");

            #endregion

            #region UserId

            string userIdStr = columns[Array.IndexOf(headers, "UserId")].TrimQuotes();
            if (!uint.TryParse(userIdStr, out var userId))
                throw new Exception($"User id '{userIdStr}' isn't valid");

            if (!userIds.Contains(userId))
                throw new Exception($"User with id '{userId}' doesn't exist");

            #endregion

            #region GenderId

            string genderIdStr = columns[Array.IndexOf(headers, "GenderId")].TrimQuotes();
            if (!char.TryParse(genderIdStr, out var genderId))
                throw new Exception($"Gender id '{genderIdStr}' isn't valid");

            if (!genderIds.Contains(genderId))
                throw new Exception($"Gender with id '{genderId}' doesn't exist");

            #endregion

            #region CountryId

            string countryId = columns[Array.IndexOf(headers, "CountryId")].TrimQuotes();

            if (!countryIds.Contains(countryId))
                throw new Exception($"Country with id '{countryId}' doesn't exist");

            #endregion            

            #endregion

            var runner = new Runner
            {
                Id = id,
                UserId = userId,
                GenderId = genderId,
                CountryId = countryId
            };

            #region Check optional fields

            #region Date of birth

            int dateOfBirthIndex = Array.IndexOf(headers, "DateOfBirth");
            if (dateOfBirthIndex > -1)
            {
                // TODO: Add age check
                string dateOfBirthStr = columns[dateOfBirthIndex].TrimQuotes();
                if (!string.IsNullOrWhiteSpace(dateOfBirthStr))
                {
                    runner.DateOfBirth = DateTime.TryParse(dateOfBirthStr, out var dateOfBirth)
                        ? dateOfBirth
                        : throw new Exception($"DateOfBirth '{dateOfBirthStr}' isn't a valid DateTime value");
                }
            }

            #endregion

            #endregion

            return runner;
        }

        #endregion

        #region Volunteers

        public IEnumerable<Volunteer> GetVolunteersFromFile(string contentRootPath, MarathonDbContext context, ILogger<ContextInitializer> logger)
        {
            string csvVolunteersFile = Path.Combine(contentRootPath, SetupFolder, "Volunteers.csv");

            string[] csvHeaders;
            try
            {
                string[] requiredHeaders = { "Id", "GenderId", "CountryId" };
                string[] optionalHeaders = { "FirstName", "LastName" };
                csvHeaders = CheckFileHeader(csvVolunteersFile, requiredHeaders, optionalHeaders);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new Volunteer[0];
            }

            // Get keys from dependency sets
            IEnumerable<char> genderIds = context.Genders.GetKeysFromSet<Gender, char>();
            IEnumerable<string> countryIds = context.Countries.GetKeysFromSet<Country, string>();

            return File.ReadAllLines(csvVolunteersFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateVolunteer(column, csvHeaders, genderIds, countryIds))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private Volunteer CreateVolunteer(string[] columns, string[] headers, IEnumerable<char> genderIds, IEnumerable<string> countryIds)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            if (genderIds == null)
                throw new ArgumentNullException(nameof(genderIds));

            if (countryIds == null)
                throw new ArgumentNullException(nameof(countryIds));

            #region Check required fields

            #region Primary key

            string idStr = columns[Array.IndexOf(headers, "Id")].TrimQuotes();
            if (!uint.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity number");

            #endregion

            #region GenderId

            string genderIdStr = columns[Array.IndexOf(headers, "GenderId")].TrimQuotes();
            if (!char.TryParse(genderIdStr, out var genderId))
                throw new Exception($"Gender id '{genderIdStr}' isn't valid");

            if (!genderIds.Contains(genderId))
                throw new Exception($"Gender with id '{genderId}' doesn't exist");

            #endregion

            #region CountryId

            string countryId = columns[Array.IndexOf(headers, "CountryId")].TrimQuotes();

            if (!countryIds.Contains(countryId))
                throw new Exception($"Country with id '{countryId}' doesn't exist");

            #endregion

            #endregion

            var volunteer = new Volunteer
            {
                Id = id,
                GenderId = genderId,
                CountryId = countryId
            };

            #region Check optional fields

            #region First name

            int firstNameIndex = Array.IndexOf(headers, "FirstName");
            if (firstNameIndex > -1)
            {
                string firstName = columns[firstNameIndex].TrimQuotes();

                volunteer.FirstName = !string.IsNullOrWhiteSpace(firstName)
                    ? firstName
                    : throw new Exception("FirstName column in empty");
            }

            #endregion

            #region Last name

            int lastNameIndex = Array.IndexOf(headers, "LastName");
            if (lastNameIndex > -1)
            {
                string lastName = columns[lastNameIndex].TrimQuotes();

                volunteer.LastName = !string.IsNullOrEmpty(lastName)
                    ? lastName
                    : throw new Exception("LastName column is empty!");
            }

            #endregion

            #endregion

            return volunteer;
        }

        #endregion

        #region Charities

        // TODO: Get image from zip archive
        public IEnumerable<Charity> GetCharitiesFromFile(string contentRootPath, ILogger<ContextInitializer> logger)
        {
            string csvCharitiesFile = Path.Combine(contentRootPath, SetupFolder, "Charities.csv");

            string[] csvHeaders;
            try
            {
                string[] requiredHeaders = { "Id", "Name" };
                string[] optionalHeaders = { "Description", "Logo" };
                csvHeaders = CheckFileHeader(csvCharitiesFile, requiredHeaders, optionalHeaders);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new Charity[0];
            }

            return File.ReadAllLines(csvCharitiesFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateVolunteer(column, csvHeaders))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private Charity CreateVolunteer(string[] columns, string[] headers)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            #region Check required fields

            #region Primary key

            string idStr = columns[Array.IndexOf(headers, "Id")].TrimQuotes();
            if (!uint.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity number");

            #endregion

            #region Name

            string name = columns[Array.IndexOf(headers, "Name")].TrimQuotes();
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name column in empty");

            #endregion

            #endregion

            var charity = new Charity
            {
                Id = id,
                Name = name
            };

            #region Check optional fields

            #region Description

            int descriptionIndex = Array.IndexOf(headers, "Description");
            if (descriptionIndex > -1)
            {
                string descriptionStr = columns[descriptionIndex].TrimQuotes();

                charity.Description = !string.IsNullOrWhiteSpace(descriptionStr)
                    ? descriptionStr
                    : throw new Exception("Description column in empty");
            }

            #endregion

            #endregion

            return charity;
        }

        #endregion

        #region RaceKitOptions

        public IEnumerable<RaceKitOption> GetRaceKitOptionsFromFile(string contentRootPath, ILogger<ContextInitializer> logger)
        {
            string csvRaceKitOptionsFile = Path.Combine(contentRootPath, SetupFolder, "RaceKitOptions.csv");

            string[] csvHeaders;
            try
            {
                string[] requiredHeaders = { "Id", "Name", "Cost" };
                csvHeaders = CheckFileHeader(csvRaceKitOptionsFile, requiredHeaders);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new RaceKitOption[0];
            }

            return File.ReadAllLines(csvRaceKitOptionsFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateRaceKitOption(column, csvHeaders))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private RaceKitOption CreateRaceKitOption(string[] columns, string[] headers)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            #region Check required fields

            #region Primary key

            string idStr = columns[Array.IndexOf(headers, "Id")].TrimQuotes();
            if (!char.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity code");

            #endregion

            #region Name

            string name = columns[Array.IndexOf(headers, "Name")].TrimQuotes();
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name column in empty");

            #endregion

            #region Cost

            string costStr = columns[Array.IndexOf(headers, "Cost")].TrimQuotes();
            if (!decimal.TryParse(costStr, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var cost))
                throw new Exception($"Cost '{costStr}' isn't a valid decimal value");

            #endregion

            #endregion

            var raceKitOption = new RaceKitOption
            {
                Id = id,
                Name = name,
                Cost = cost
            };

            return raceKitOption;
        }

        #endregion

        #region RaceKitItems

        public IEnumerable<RaceKitItem> GetRaceKitItemsFromFile(string contentRootPath, ILogger<ContextInitializer> logger)
        {
            string csvRaceKitItemsFile = Path.Combine(contentRootPath, SetupFolder, "RaceKitItems.csv");

            string[] csvHeaders;
            try
            {
                string[] requiredHeaders = { "Id", "Name", "Count" };
                csvHeaders = CheckFileHeader(csvRaceKitItemsFile, requiredHeaders);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new RaceKitItem[0];
            }

            return File.ReadAllLines(csvRaceKitItemsFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateRaceKitItem(column, csvHeaders))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private RaceKitItem CreateRaceKitItem(string[] columns, string[] headers)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            #region Check required fields

            #region Primary key

            string idStr = columns[Array.IndexOf(headers, "Id")].TrimQuotes();
            if (!ushort.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity number");

            #endregion

            #region Name

            string name = columns[Array.IndexOf(headers, "Name")].TrimQuotes();
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name column in empty");

            #endregion

            #region Count

            string countStr = columns[Array.IndexOf(headers, "Count")].TrimQuotes();
            if (!uint.TryParse(countStr, out var count))
                throw new Exception($"Count '{countStr}' isn't a valid integer value");

            #endregion

            #endregion

            var raceKitOption = new RaceKitItem
            {
                Id = id,
                Name = name,
                Count = count
            };

            return raceKitOption;
        }

        #endregion

        #region OptionItems

        public IEnumerable<RaceKitOptionItem> GetOptionItemsFromFile(string contentRootPath, MarathonDbContext context, ILogger<ContextInitializer> logger)
        {
            string csvOptionItemsFile = Path.Combine(contentRootPath, SetupFolder, "OptionItem.csv");

            string[] csvHeaders;
            try
            {
                string[] requiredHeaders = { "OptionId", "ItemId" };
                csvHeaders = CheckFileHeader(csvOptionItemsFile, requiredHeaders);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new RaceKitOptionItem[0];
            }

            // Get keys from dependency sets
            IEnumerable<char> optionIds = context.RaceKitOptions.GetKeysFromSet<RaceKitOption, char>();
            IEnumerable<ushort> itemIds = context.RaceKitItems.GetKeysFromSet<RaceKitItem, ushort>();

            return File.ReadAllLines(csvOptionItemsFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateOptionItem(column, csvHeaders, optionIds, itemIds))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private RaceKitOptionItem CreateOptionItem(string[] columns, string[] headers, IEnumerable<char> optionIds, IEnumerable<ushort> itemIds)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            if (optionIds == null)
                throw new ArgumentNullException(nameof(optionIds));

            if (itemIds == null)
                throw new ArgumentNullException(nameof(itemIds));

            #region Check required fields

            #region Primary key

            string optionIdStr = columns[Array.IndexOf(headers, "OptionId")].TrimQuotes();
            if (!char.TryParse(optionIdStr, out var optionId))
                throw new Exception($"OptionId '{optionIdStr}' isn't a valid value of part of primary key");

            if (!optionIds.Contains(optionId))
                throw new Exception($"Race kit option '{optionId}' doesn't exist in dependent set");

            string itemIdStr = columns[Array.IndexOf(headers, "ItemId")].TrimQuotes();
            if (!ushort.TryParse(itemIdStr, out var itemId))
                throw new Exception($"ItemId '{itemIdStr}' isn't a valid value of part of primary key");

            if (!itemIds.Contains(itemId))
                throw new Exception($"Race kit item '{itemId}' doesn't exist in dependent set");

            #endregion

            #endregion

            var raceKitOptionItem = new RaceKitOptionItem
            {
                OptionId = optionId,
                ItemId = itemId
            };

            return raceKitOptionItem;
        }

        #endregion

        #region MarathonSignUps

        public IEnumerable<MarathonSignUp> GetMarathonSignUpsFromFile(string contentRootPath, MarathonDbContext context, ILogger<ContextInitializer> logger)
        {
            string csvMarathonSignUpsFile = Path.Combine(contentRootPath, SetupFolder, "MarathonSignUps.csv");

            string[] csvHeaders;
            try
            {
                string[] requiredHeaders = { "Id", "SignUpDate", "Cost", "SponsorshipTarget", "RunnerId", "CharityId", "RaceKitOptionId", "SignUpStatusId" };
                csvHeaders = CheckFileHeader(csvMarathonSignUpsFile, requiredHeaders);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new MarathonSignUp[0];
            }

            // Get keys from dependency sets
            IEnumerable<uint> runnerIds = context.Runners.GetKeysFromSet<Runner, uint>();
            IEnumerable<uint> charityIds = context.Charities.GetKeysFromSet<Charity, uint>();
            IEnumerable<byte> signUpStatusIds = context.SignUpStatuses.GetKeysFromSet<SignUpStatus, byte>();
            IEnumerable<char> raceKitOptionIds = context.RaceKitOptions.GetKeysFromSet<RaceKitOption, char>();

            return File.ReadAllLines(csvMarathonSignUpsFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateMarathonSignUp(column, csvHeaders, runnerIds, charityIds, signUpStatusIds, raceKitOptionIds))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private MarathonSignUp CreateMarathonSignUp(string[] columns, string[] headers, IEnumerable<uint> runnerIds, IEnumerable<uint> charityIds, IEnumerable<byte> signUpStatusIds, IEnumerable<char> raceKitOptionIds)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            if (runnerIds == null)
                throw new ArgumentNullException(nameof(runnerIds));

            if (charityIds == null)
                throw new ArgumentNullException(nameof(charityIds));

            if (signUpStatusIds == null)
                throw new ArgumentNullException(nameof(signUpStatusIds));

            if (raceKitOptionIds == null)
                throw new ArgumentNullException(nameof(raceKitOptionIds));

            #region Check required fields

            #region Primary key

            string idStr = columns[Array.IndexOf(headers, "Id")].TrimQuotes();
            if (!uint.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity number");

            #endregion

            #region RunnerId

            string runnerIdStr = columns[Array.IndexOf(headers, "RunnerId")].TrimQuotes();
            if (!uint.TryParse(runnerIdStr, out var runnerId))
                throw new Exception($"Runner id '{runnerIdStr}' isn't a valid");

            if (!runnerIds.Contains(runnerId))
                throw new Exception($"Runner with id '{runnerId}' doesn't exist");

            #endregion

            #region RaceKitOptionId

            string raceKitOptionIdStr = columns[Array.IndexOf(headers, "RaceKitOptionId")].TrimQuotes();
            if (!char.TryParse(raceKitOptionIdStr, out var raceKitOptionId))
                throw new Exception($"Race kit option id '{raceKitOptionIdStr}' isn't a valid");

            if (!raceKitOptionIds.Contains(raceKitOptionId))
                throw new Exception($"Race kit option with id '{raceKitOptionId}' doesn't exist");

            #endregion

            #region SignUpStatusId

            string signUpStatusIdStr = columns[Array.IndexOf(headers, "SignUpStatusId")].TrimQuotes();
            if (!byte.TryParse(signUpStatusIdStr, out var signUpStatusId))
                throw new Exception($"Sign up status id '{signUpStatusIdStr}' isn't a valid");

            if (!signUpStatusIds.Contains(signUpStatusId))
                throw new Exception($"Sign up status with id '{signUpStatusId}' doesn't exist");

            #endregion

            #region CharityId

            string charityIdStr = columns[Array.IndexOf(headers, "CharityId")].TrimQuotes();
            if (!uint.TryParse(charityIdStr, out var charityId))
                throw new Exception($"Charity id '{charityIdStr}' isn't a valid");

            if (!charityIds.Contains(charityId))
                throw new Exception($"Charity with id '{charityId}' doesn't exist");

            #endregion

            #region SignUpDate

            string signUpDateStr = columns[Array.IndexOf(headers, "SignUpDate")].TrimQuotes();
            if (!DateTime.TryParse(signUpDateStr, out var signUpDate))
                throw new Exception($"Sign up date '{signUpDateStr}' isn't a valid");

            if (signUpDate.Date.ToUniversalTime() > DateTime.Now.ToUniversalTime())
                throw new Exception("Sign up date is larger than current date");

            #endregion

            #region Cost

            string costStr = columns[Array.IndexOf(headers, "Cost")].TrimQuotes();
            if (!decimal.TryParse(costStr, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var cost))
                throw new Exception($"Cost '{costStr}' isn't a valid decimal value");

            #endregion

            #region SponsorshipTarget

            string sponsorshipTargetStr = columns[Array.IndexOf(headers, "SponsorshipTarget")].TrimQuotes();
            if (!decimal.TryParse(sponsorshipTargetStr, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var sponsorshipTarget))
                throw new Exception($"SponsorshipTarget '{sponsorshipTargetStr}' isn't a valid decimal value");

            #endregion

            #endregion

            var marathonSignUp = new MarathonSignUp
            {
                Id = id,
                RunnerId = runnerId,
                SignUpDate = signUpDate,
                RaceKitOptionId = raceKitOptionId,
                Cost = cost,
                CharityId = charityId,
                SponsorshipTarget = sponsorshipTarget
            };

            return marathonSignUp;
        }

        #endregion

        #region Sponsorships

        public IEnumerable<Sponsorship> GetSponsorshipsFromFile(string contentRootPath, MarathonDbContext context, ILogger<ContextInitializer> logger)
        {
            string csvSponsorshipsFile = Path.Combine(contentRootPath, SetupFolder, "Sponsorships.csv");

            string[] csvHeaders;
            try
            {
                string[] requiredHeaders = { "Id", "Name", "SignUpId", "Amount" };
                csvHeaders = CheckFileHeader(csvSponsorshipsFile, requiredHeaders);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new Sponsorship[0];
            }

            // Get keys from dependency sets
            IEnumerable<uint> signUpIds = context.MarathonSignUps.GetKeysFromSet<MarathonSignUp, uint>();

            return File.ReadAllLines(csvSponsorshipsFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateSponsorship(column, csvHeaders, signUpIds))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private Sponsorship CreateSponsorship(string[] columns, string[] headers, IEnumerable<uint> signUpIds)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            if (signUpIds == null)
                throw new ArgumentNullException(nameof(signUpIds));

            #region Check required fields

            #region Primary key

            string idStr = columns[Array.IndexOf(headers, "Id")].TrimQuotes();
            if (!uint.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity number");

            #endregion

            #region Name

            string name = columns[Array.IndexOf(headers, "Name")].TrimQuotes();
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name column is empty");

            #endregion

            #region SignUpId

            string signUpIdStr = columns[Array.IndexOf(headers, "SignUpId")].TrimQuotes();
            if (!uint.TryParse(signUpIdStr, out var signUpId))
                throw new Exception($"Sign up id '{signUpIdStr}' isn't a valid");

            if (!signUpIds.Contains(signUpId))
                throw new Exception($"Sign up with id '{signUpId}' doesn't exist");

            #endregion

            #region Amount

            string amountStr = columns[Array.IndexOf(headers, "Amount")].TrimQuotes();
            if (!decimal.TryParse(amountStr, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var amount))
                throw new Exception($"Amount '{amountStr}' isn't a valid decimal value");

            #endregion

            #endregion

            var sponsorship = new Sponsorship
            {
                Id = id,
                Name = name,
                SignUpId = signUpId,
                Amount = amount
            };

            return sponsorship;
        }

        #endregion

        #region Marathons

        public IEnumerable<Domain.Entities.Marathon> GetMarathonsFromFile(string contentRootPath, MarathonDbContext context, ILogger<ContextInitializer> logger)
        {
            string csvMarathonsFile = Path.Combine(contentRootPath, SetupFolder, "Marathons.csv");

            string[] csvHeaders;
            try
            {
                string[] requiredHeaders = { "Id", "Name", "CountryId" };
                string[] optionalHeaders = { "City", "YearHeld" };
                csvHeaders = CheckFileHeader(csvMarathonsFile, requiredHeaders, optionalHeaders);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new Domain.Entities.Marathon[0];
            }

            // Get keys from dependency sets
            IEnumerable<string> countryIds = context.Countries.GetKeysFromSet<Country, string>();

            return File.ReadAllLines(csvMarathonsFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateMarathon(column, csvHeaders, countryIds))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private Domain.Entities.Marathon CreateMarathon(string[] columns, string[] headers, IEnumerable<string> countryIds)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            if (countryIds == null)
                throw new ArgumentNullException(nameof(countryIds));

            #region Check required fields

            #region Primary key

            string idStr = columns[Array.IndexOf(headers, "Id")].TrimQuotes();
            if (!byte.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity number");

            #endregion

            #region Name

            string name = columns[Array.IndexOf(headers, "Name")].TrimQuotes();
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name column is empty");

            #endregion

            #region CountryId

            string countryId = columns[Array.IndexOf(headers, "CountryId")].TrimQuotes();

            if (!countryIds.Contains(countryId))
                throw new Exception($"Country with id '{countryId}' doesn't exist");

            #endregion

            #endregion

            var marathon = new Domain.Entities.Marathon
            {
                Id = id,
                Name = name,
                CountryId = countryId
            };

            #region Check optional fields

            #region City

            int cityIndex = Array.IndexOf(headers, "City");
            if (cityIndex > -1)
            {
                string city = columns[cityIndex].TrimQuotes();

                marathon.City = !string.IsNullOrWhiteSpace(city)
                        ? city
                        : throw new Exception("City column in empty");
            }

            #endregion

            #region YearHeld

            int yearHeldIndex = Array.IndexOf(headers, "YearHeld");
            if (yearHeldIndex > -1)
            {
                string yearHeldStr = columns[yearHeldIndex].TrimQuotes();
                if (!ushort.TryParse(yearHeldStr, out var yearHeld))
                    throw new Exception("Year held value isn't a valid");

                marathon.YearHeld = yearHeld;
            }

            #endregion

            #endregion

            return marathon;
        }

        #endregion

        #region EventTypes

        public IEnumerable<EventType> GetEventTypesFromFile(string contentRootPath, ILogger<ContextInitializer> logger)
        {
            string csvEventTypesFile = Path.Combine(contentRootPath, SetupFolder, "EventTypes.csv");

            string[] csvHeaders;
            try
            {
                string[] requiredHeaders = { "Id", "Name" };
                csvHeaders = CheckFileHeader(csvEventTypesFile, requiredHeaders);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new EventType[0];
            }

            return File.ReadAllLines(csvEventTypesFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateEventType(column, csvHeaders))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private EventType CreateEventType(string[] columns, string[] headers)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            #region Check required fields

            #region Primary key

            string id = columns[Array.IndexOf(headers, "Id")].TrimQuotes();
            if (string.IsNullOrWhiteSpace(id))
                throw new Exception($"Id '{id}' isn't a valid identity key");

            #endregion

            #region Name

            string name = columns[Array.IndexOf(headers, "Name")].TrimQuotes();
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name column is empty");

            #endregion

            #endregion

            var eventType = new EventType
            {
                Id = id,
                Name = name
            };

            return eventType;
        }

        #endregion

        #region Events

        public IEnumerable<Event> GetEventsFromFile(string contentRootPath, MarathonDbContext context, ILogger<ContextInitializer> logger)
        {
            string csvEventsFile = Path.Combine(contentRootPath, SetupFolder, "Events.csv");

            string[] csvHeaders;
            try
            {
                string[] requiredHeaders = { "Id", "Name", "MarathonId", "EventTypeId" };
                string[] optionalHeaders = { "Cost", "StartDate", "MaxParticipants" };
                csvHeaders = CheckFileHeader(csvEventsFile, requiredHeaders, optionalHeaders);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new Event[0];
            }

            // Get keys from dependency sets
            IEnumerable<string> eventTypeIds = context.EventTypes.GetKeysFromSet<EventType, string>();
            IEnumerable<byte> marathonIds = context.Marathons.GetKeysFromSet<Domain.Entities.Marathon, byte>();

            return File.ReadAllLines(csvEventsFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateEvent(column, csvHeaders, eventTypeIds, marathonIds))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private Event CreateEvent(string[] columns, string[] headers, IEnumerable<string> eventTypeIds, IEnumerable<byte> marathonIds)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            if (eventTypeIds == null)
                throw new ArgumentNullException(nameof(eventTypeIds));

            if (marathonIds == null)
                throw new ArgumentNullException(nameof(marathonIds));

            #region Check required fields

            #region Primary key

            string id = columns[Array.IndexOf(headers, "Id")].TrimQuotes();
            if (string.IsNullOrWhiteSpace(id))
                throw new Exception($"Id '{id}' isn't a valid identity key");

            #endregion

            #region Name

            string name = columns[Array.IndexOf(headers, "Name")].TrimQuotes();

            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name column is empty");

            #endregion

            #region EventTypeId

            string eventTypeId = columns[Array.IndexOf(headers, "EventTypeId")].TrimQuotes();

            if (string.IsNullOrWhiteSpace(eventTypeId))
                throw new Exception("EventTypeId column is empty");

            if (!eventTypeIds.Contains(eventTypeId))
                throw new Exception($"Event type with id '{eventTypeId}' doesn't exist");

            #endregion

            #region MarathonId

            string marathonIdStr = columns[Array.IndexOf(headers, "MarathonId")].TrimQuotes();
            if (!byte.TryParse(marathonIdStr, out var marathonId))
                throw new Exception($"Marathon id '{marathonIdStr}' isn't a valid");

            if (!marathonIds.Contains(marathonId))
                throw new Exception($"Marathon with id '{marathonId}' doesn't exist");

            #endregion            

            #endregion

            var newEvent = new Event
            {
                Id = id,
                Name = name,
                EventTypeId = eventTypeId,
                MarathonId = marathonId
            };

            #region Check optional fields

            #region Start date

            int startDateIndex = Array.IndexOf(headers, "StartDate");
            if (startDateIndex > -1)
            {
                string startDateStr = columns[startDateIndex].TrimQuotes();
                if (!string.IsNullOrWhiteSpace(startDateStr))
                {
                    newEvent.StartDate = DateTime.TryParse(startDateStr, out var startDate)
                        ? startDate
                        : throw new Exception($"StartDate '{startDateStr}' isn't a valid DateTime value");
                }
            }

            #endregion

            #region Cost

            int costIndex = Array.IndexOf(headers, "Cost");
            if (costIndex > -1)
            {
                string costStr = columns[costIndex].TrimQuotes();
                if (!string.IsNullOrWhiteSpace(costStr))
                {
                    newEvent.Cost = decimal.TryParse(costStr, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var cost)
                        ? cost
                        : throw new Exception($"Cost '{costStr}' isn't a valid decimal value");
                }
            }

            #endregion

            #region MaxParticipants

            int maxParticipantsIndex = Array.IndexOf(headers, "MaxParticipants");
            if (maxParticipantsIndex > -1)
            {
                string maxParticipantsStr = columns[maxParticipantsIndex].TrimQuotes();
                if (!string.IsNullOrWhiteSpace(maxParticipantsStr))
                {
                    newEvent.MaxParticipants = ushort.TryParse(maxParticipantsStr, out var maxParticipants)
                        ? maxParticipants
                        : throw new Exception($"Max Participants '{maxParticipantsStr}' isn't a valid integer value");
                }
            }

            #endregion

            #endregion

            return newEvent;
        }

        #endregion

        #region SignUpMarathonEvents

        public IEnumerable<SignUpMarathonEvent> GetSignUpMarathonEventsFromFile(string contentRootPath, MarathonDbContext context, ILogger<ContextInitializer> logger)
        {
            string csvSignUpMarathonEventsFile = Path.Combine(contentRootPath, SetupFolder, "SignUpMarathonEvents.csv");

            string[] csvHeaders;
            try
            {
                string[] requiredHeaders = { "Id", "EventId", "SignUpId" };
                string[] optionalHeaders = { "BibNumber", "RaceTime" };
                csvHeaders = CheckFileHeader(csvSignUpMarathonEventsFile, requiredHeaders, optionalHeaders);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new SignUpMarathonEvent[0];
            }

            // Get keys from dependency sets
            IEnumerable<uint> signUpIds = context.MarathonSignUps.GetKeysFromSet<MarathonSignUp, uint>();
            IEnumerable<string> eventIds = context.Events.GetKeysFromSet<Event, string>();

            return File.ReadAllLines(csvSignUpMarathonEventsFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateSignUpMarathonEvent(column, csvHeaders, signUpIds, eventIds))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private SignUpMarathonEvent CreateSignUpMarathonEvent(string[] columns, string[] headers, IEnumerable<uint> signUpIds, IEnumerable<string> eventIds)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            if (signUpIds == null)
                throw new ArgumentNullException(nameof(signUpIds));

            if (eventIds == null)
                throw new ArgumentNullException(nameof(eventIds));

            #region Check required fields

            #region Primary key

            string idStr = columns[Array.IndexOf(headers, "Id")].TrimQuotes();
            if (!uint.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity number");

            #endregion

            #region SignUpId

            string signUpIdStr = columns[Array.IndexOf(headers, "SignUpId")].TrimQuotes();
            if (!uint.TryParse(signUpIdStr, out var signUpId))
                throw new Exception($"Sign up id '{signUpIdStr}' isn't a valid");

            #endregion

            #region EventId

            string eventId = columns[Array.IndexOf(headers, "EventId")].TrimQuotes();

            if (!eventIds.Contains(eventId))
                throw new Exception($"Event with id '{eventId}' doesn't exist");

            #endregion

            #endregion

            var signUpMarathonEvent = new SignUpMarathonEvent
            {
                Id = id,
                SignUpId = signUpId,
                EventId = eventId
            };

            #region Check optional fields

            #region Bib number

            int bibNumberIndex = Array.IndexOf(headers, "BibNumber");
            if (bibNumberIndex > -1)
            {
                string bibNumberStr = columns[bibNumberIndex].TrimQuotes();
                if (!string.IsNullOrWhiteSpace(bibNumberStr))
                {
                    signUpMarathonEvent.BibNumber = ushort.TryParse(bibNumberStr, out var bibNumber)
                        ? bibNumber
                        : throw new Exception($"Bib number '{bibNumberStr}' isn't a valid integer value");
                }
            }

            #endregion

            #region Race time

            int raceTimeIndex = Array.IndexOf(headers, "RaceTime");
            if (raceTimeIndex > -1)
            {
                string raceTimeStr = columns[raceTimeIndex].TrimQuotes();
                if (!string.IsNullOrWhiteSpace(raceTimeStr))
                {
                    signUpMarathonEvent.RaceTime = uint.TryParse(raceTimeStr, out var raceTime)
                        ? raceTime
                        : throw new Exception($"Race time '{raceTimeStr}' isn't a valid integer value");
                }
            }

            #endregion

            #endregion

            return signUpMarathonEvent;
        }

        #endregion

        #endregion

        #region Helpers

        /// <summary>
        /// Gets temporary folder for extract archive (*.zip, *.rar, *.7z, e.t.c...) 
        /// </summary>
        /// <param name="contentRootPath">Root path of content folder</param>
        /// <param name="subFolder">Temporary folder name of content setup directory</param>
        private string GetTemporarySetupFolder(string contentRootPath, string subFolder) => Path.Combine(contentRootPath, SetupFolder, subFolder);


        /// <summary>
        /// Compares CSV columns headers with <param name="requiredHeaders"></param> and <param name="optionalHeaders"></param>
        /// </summary>
        /// <param name="csvFile">Path to CSV file</param>
        /// <param name="requiredHeaders"></param>
        /// <param name="optionalHeaders"></param>
        private string[] CheckFileHeader(string csvFile, string[] requiredHeaders, string[] optionalHeaders = null)
        {
            string[] csvHeaders = File.ReadLines(csvFile)
                                      .First()
                                      .ToLowerInvariant()
                                      .Split(',');

            if (csvHeaders.Length < requiredHeaders.Length)
                throw new Exception($"RequiredHeader count '{requiredHeaders.Length}' is bigger then csv header count '{csvHeaders.Length}' ");

            if (optionalHeaders != null)
                if (csvHeaders.Length > (requiredHeaders.Length + optionalHeaders.Length))
                    throw new Exception($"CSV header count '{csvHeaders.Length}'  is larger then required '{requiredHeaders.Length}' and optional '{optionalHeaders.Count()}' headers count");

            foreach (var requiredHeader in requiredHeaders)
                if (!csvHeaders.Contains(requiredHeader))
                    throw new Exception($"Does not contain required header '{requiredHeader}'");

            return csvHeaders;
        }

        /// <summary>
        /// Create policy for thread-safe catch exceptions while data seed and try complete failed operation again
        /// </summary>
        /// <param name="logger">Logger to show exceptions</param>
        /// <param name="prefix">Type of exception provoker</param>
        /// <param name="retries">Count of attempts to retry again</param>
        private Policy CreatePolicy(ILogger<ContextInitializer> logger, string prefix, int retries = 3)
        {
            return Policy.Handle<SqlException>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        logger.LogTrace($"[{prefix}] Exception {exception.GetType().Name} with message ${exception.Message} detected on attempt {retry} of {retries}");
                    }
                );
        }

        /// <summary>
        /// Seed linked enumeration to set of database context
        /// </summary>
        /// <typeparam name="TEntity">Entity of context</typeparam>
        /// <typeparam name="TKey">Key field of entity</typeparam>
        /// <typeparam name="TEntityEnum">Linked enumeration</typeparam>
        /// <param name="repository">Set of context entities</param>
        /// <param name="items">List of linked enumeration instances</param>
        public void SeedEnumeration<TEntity, TKey, TEntityEnum>(DbSet<TEntity> repository, IEnumerable<TEntityEnum> items)
            where TEntity : class, IEnumEntity<TKey>, new()
            where TEntityEnum : Enumeration<TKey, TEntity>
        {
            var enumList = items.AsQueryable();

            foreach (var item in enumList.Select(Enumeration<TKey, TEntity>.Projection))
                repository.Add(item);
        }
    }

    #endregion
}