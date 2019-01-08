﻿using Polly;
using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Marathon.Domain.Common;
using Marathon.Domain.Entities;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
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

                if (!context.Events.Any())
                {
                    await context.Events.AddRangeAsync(GetEventsFromFile(contentRootPath, context, logger));
                    await context.SaveChangesAsync();
                }

                if (!context.Users.Any())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        SetIdentityInsert(context, "Users", true);

                        await context.Users.AddRangeAsync(GetUsersFromFile(contentRootPath, context, logger));
                        await context.SaveChangesAsync();

                        SetIdentityInsert(context, "Users", false);

                        transaction.Commit();
                    }

                }

                if (!context.Volunteers.Any())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        SetIdentityInsert(context, "Volunteers", true);

                        await context.Volunteers.AddRangeAsync(GetVolunteersFromFile(contentRootPath, context, logger));
                        await context.SaveChangesAsync();

                        SetIdentityInsert(context, "Volunteers", false);

                        transaction.Commit();
                    }
                }

                if (!context.Runners.Any())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        SetIdentityInsert(context, "Runners", true);

                        await context.Runners.AddRangeAsync(GetRunnersFromFile(contentRootPath, context, logger));
                        await context.SaveChangesAsync();

                        SetIdentityInsert(context, "Runners", false);

                        transaction.Commit();
                    }
                }

                if (!context.Charities.Any())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        SetIdentityInsert(context, "Charities", true);

                        await context.Charities.AddRangeAsync(GetCharitiesFromFile(contentRootPath, logger));
                        await context.SaveChangesAsync();

                        SetIdentityInsert(context, "Charities", false);

                        transaction.Commit();
                    }
                }

                if (!context.RaceKitOptions.Any())
                {
                    await context.RaceKitOptions.AddRangeAsync(GetRaceKitOptionsFromFile(contentRootPath, logger));
                    await context.SaveChangesAsync();
                }

                if (!context.RaceKitItems.Any())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        SetIdentityInsert(context, "RaceKitItems", true);

                        await context.RaceKitItems.AddRangeAsync(GetRaceKitItemsFromFile(contentRootPath, logger));
                        await context.SaveChangesAsync();

                        SetIdentityInsert(context, "RaceKitItems", false);

                        transaction.Commit();
                    }
                }

                if (!context.RaceKitOptionItems.Any())
                {
                    await context.RaceKitOptionItems.AddRangeAsync(GetOptionItemsFromFile(contentRootPath, context, logger));
                    await context.SaveChangesAsync();
                }

                if (!context.MarathonSignUps.Any())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        SetIdentityInsert(context, "Registration", true);

                        await context.MarathonSignUps.AddRangeAsync(GetMarathonSignUpsFromFile(contentRootPath, context, logger));
                        await context.SaveChangesAsync();

                        SetIdentityInsert(context, "Registration", false);

                        transaction.Commit();
                    }
                }

                if (!context.Sponsorships.Any())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        SetIdentityInsert(context, "Sponsorships", true);

                        await context.Sponsorships.AddRangeAsync(GetSponsorshipsFromFile(contentRootPath, context, logger));
                        await context.SaveChangesAsync();

                        SetIdentityInsert(context, "Sponsorships", false);

                        transaction.Commit();
                    }
                }

                if (!context.SignUpMarathonEvents.Any())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        SetIdentityInsert(context, "RegistrationEvent", true);

                        await context.SignUpMarathonEvents.AddRangeAsync(GetSignUpMarathonEventsFromFile(contentRootPath, context, logger));
                        await context.SaveChangesAsync();

                        SetIdentityInsert(context, "RegistrationEvent", false);

                        transaction.Commit();
                    }
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
                       .SelectTry(column => CreateCountry(column, csvHeaders, contentRootPath, logger))
                       .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                       .Where(x => x?.Flag != null);
        }

        private Country CreateCountry(string[] columns, string[] headers, string contentRootPath, ILogger<ContextInitializer> logger)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            #region Check required fields

            #region Primary key

            string id = columns[Array.FindIndex(headers, h => h.Equals("Id", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (string.IsNullOrWhiteSpace(id))
                throw new Exception($"Id '{id}' isn't a valid identity key");

            #endregion

            #region Name

            string name = columns[Array.FindIndex(headers, h => h.Equals("Name", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name column is empty");

            #endregion

            #endregion

            var country = new Country
            {
                Id = id,
                Name = name,
            };

            country.Flag = GetCountryFlag(contentRootPath, country, logger);

            return country;
        }

        private byte[] GetCountryFlag(string contentRootPath, Country country, ILogger<ContextInitializer> logger)
        {
            string archivePath = Path.Combine(contentRootPath, SetupFolder, "Countries.zip");

            ZipArchive archive = null;

            try
            {
                const string fileNamePrefix = "flag_";
                const string fileExtension = ".png";

                archive = ZipFile.OpenRead(archivePath);

                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.Name.StartsWith(fileNamePrefix, StringComparison.OrdinalIgnoreCase) &&
                        entry.FullName.EndsWith(fileExtension, StringComparison.OrdinalIgnoreCase))
                    {
                        string nameWithoutPrefix =
                            StripPrefix(Path.GetFileNameWithoutExtension(entry.Name), fileNamePrefix)
                                .Replace('_', ' ')
                                .Replace('-', ' ');

                        if (!country.Name.Equals(nameWithoutPrefix, StringComparison.InvariantCultureIgnoreCase) &&
                            !country.Id.Equals(nameWithoutPrefix, StringComparison.InvariantCultureIgnoreCase))
                            continue;

                        using (Stream source = entry.Open())
                        using (MemoryStream buffer = new MemoryStream())
                        {
                            source.CopyTo(buffer);
                            return buffer.ToArray();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                archive?.Dispose();
            }
            return null;
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

            string idStr = columns[Array.FindIndex(headers, h => h.Equals("Id", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!int.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity number");

            #endregion

            #region Email

            string email = columns[Array.FindIndex(headers, h => h.Equals("Email", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!IsValidEmail(email))
                throw new Exception($"Email string '{email}' isn't valid");

            #endregion

            #region Password

            // TODO: Add password regex check
            string password = columns[Array.FindIndex(headers, h => h.Equals("Password", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password column is empty!");

            #endregion

            #region UserTypeId

            string userTypeStr = columns[Array.FindIndex(headers, h => h.Equals("UserTypeId", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
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

            int firstNameIndex = Array.FindIndex(headers, h => h.Equals("FirstName", StringComparison.OrdinalIgnoreCase));
            if (firstNameIndex > -1)
            {
                string firstName = columns[firstNameIndex].TrimQuotes();

                user.FirstName = !string.IsNullOrWhiteSpace(firstName)
                    ? firstName
                    : throw new Exception("FirstName column in empty");
            }

            #endregion

            #region Last name

            int lastNameIndex = Array.FindIndex(headers, h => h.Equals("LastName", StringComparison.OrdinalIgnoreCase));
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
            IEnumerable<int> userIds = context.Users.GetKeysFromSet<User, int>();
            IEnumerable<char> genderIds = context.Genders.GetKeysFromSet<Gender, char>();
            IEnumerable<string> countryIds = context.Countries.GetKeysFromSet<Country, string>();

            return File.ReadAllLines(csvRunnersFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateRunner(column, csvHeaders, userIds, genderIds, countryIds))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private Runner CreateRunner(string[] columns, string[] headers, IEnumerable<int> userIds, IEnumerable<char> genderIds, IEnumerable<string> countryIds)
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

            string idStr = columns[Array.FindIndex(headers, h => h.Equals("Id", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!int.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity number");

            #endregion

            #region UserId

            string userIdStr = columns[Array.FindIndex(headers, h => h.Equals("UserId", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!int.TryParse(userIdStr, out var userId))
                throw new Exception($"User id '{userIdStr}' isn't valid");

            if (!userIds.Contains(userId))
                throw new Exception($"User with id '{userId}' doesn't exist");

            #endregion

            #region GenderId

            string genderIdStr = columns[Array.FindIndex(headers, h => h.Equals("GenderId", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!char.TryParse(genderIdStr, out var genderId))
                throw new Exception($"Gender id '{genderIdStr}' isn't valid");

            if (!genderIds.Contains(genderId))
                throw new Exception($"Gender with id '{genderId}' doesn't exist");

            #endregion

            #region CountryId

            string countryId = columns[Array.FindIndex(headers, h => h.Equals("CountryId", StringComparison.OrdinalIgnoreCase))].TrimQuotes();

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

            int dateOfBirthIndex = Array.FindIndex(headers, h => h.Equals("DateOfBirth", StringComparison.OrdinalIgnoreCase));
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

            string idStr = columns[Array.FindIndex(headers, h => h.Equals("Id", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!int.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity number");

            #endregion

            #region GenderId

            string genderIdStr = columns[Array.FindIndex(headers, h => h.Equals("GenderId", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!char.TryParse(genderIdStr, out var genderId))
                throw new Exception($"Gender id '{genderIdStr}' isn't valid");

            if (!genderIds.Contains(genderId))
                throw new Exception($"Gender with id '{genderId}' doesn't exist");

            #endregion

            #region CountryId

            string countryId = columns[Array.FindIndex(headers, h => h.Equals("CountryId", StringComparison.OrdinalIgnoreCase))].TrimQuotes();

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

            int firstNameIndex = Array.FindIndex(headers, h => h.Equals("FirstName", StringComparison.OrdinalIgnoreCase));
            if (firstNameIndex > -1)
            {
                string firstName = columns[firstNameIndex].TrimQuotes();

                volunteer.FirstName = !string.IsNullOrWhiteSpace(firstName)
                    ? firstName
                    : throw new Exception("FirstName column in empty");
            }

            #endregion

            #region Last name

            int lastNameIndex = Array.FindIndex(headers, h => h.Equals("LastName", StringComparison.OrdinalIgnoreCase));
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

        // TODO: Needs to fix select regex
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
                       .SelectTry(column => CreateVolunteer(column, csvHeaders, contentRootPath, logger))
                       .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                       .Where(x => x != null);
        }

        private Charity CreateVolunteer(string[] columns, string[] headers, string contentRootPath, ILogger<ContextInitializer> logger)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            #region Check required fields

            #region Primary key

            string idStr = columns[Array.FindIndex(headers, h => h.Equals("Id", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!int.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity number");

            #endregion

            #region Name

            string name = columns[Array.FindIndex(headers, h => h.Equals("Name", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
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

            int descriptionIndex = Array.FindIndex(headers, h => h.Equals("Description", StringComparison.OrdinalIgnoreCase));
            if (descriptionIndex > -1)
            {
                string descriptionStr = columns[descriptionIndex].TrimQuotes();

                charity.Description = !string.IsNullOrWhiteSpace(descriptionStr)
                    ? descriptionStr
                    : throw new Exception("Description column in empty");
            }

            #endregion

            #endregion

            charity.Logo = GetCharitiesLogo(contentRootPath, charity, logger);

            return charity;
        }

        private byte[] GetCharitiesLogo(string contentRootPath, Charity charity, ILogger<ContextInitializer> logger)
        {
            string archivePath = Path.Combine(contentRootPath, SetupFolder, "Charities.zip");

            ZipArchive archive = null;

            try
            {
                const string fileExtension = ".png";

                archive = ZipFile.OpenRead(archivePath);

                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(fileExtension, StringComparison.OrdinalIgnoreCase))
                    {
                        string fileName = Path.GetFileNameWithoutExtension(entry.Name);

                        if (!charity.Name.Equals(fileName, StringComparison.InvariantCultureIgnoreCase))
                            continue;


                        using (Stream source = entry.Open())
                        using (MemoryStream buffer = new MemoryStream())
                        {
                            source.CopyTo(buffer);
                            return buffer.ToArray();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                archive?.Dispose();
            }

            return null;
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

            string idStr = columns[Array.FindIndex(headers, h => h.Equals("Id", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!char.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity code");

            #endregion

            #region Name

            string name = columns[Array.FindIndex(headers, h => h.Equals("Name", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name column in empty");

            #endregion

            #region Cost

            string costStr = columns[Array.FindIndex(headers, h => h.Equals("Cost", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
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

            string idStr = columns[Array.FindIndex(headers, h => h.Equals("Id", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!short.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity number");

            #endregion

            #region Name

            string name = columns[Array.FindIndex(headers, h => h.Equals("Name", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name column in empty");

            #endregion

            #region Count

            string countStr = columns[Array.FindIndex(headers, h => h.Equals("Count", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!int.TryParse(countStr, out var count))
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
            IEnumerable<short> itemIds = context.RaceKitItems.GetKeysFromSet<RaceKitItem, short>();

            return File.ReadAllLines(csvOptionItemsFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateOptionItem(column, csvHeaders, optionIds, itemIds))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private RaceKitOptionItem CreateOptionItem(string[] columns, string[] headers, IEnumerable<char> optionIds, IEnumerable<short> itemIds)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            if (optionIds == null)
                throw new ArgumentNullException(nameof(optionIds));

            if (itemIds == null)
                throw new ArgumentNullException(nameof(itemIds));

            #region Check required fields

            #region Primary key

            string optionIdStr = columns[Array.FindIndex(headers, h => h.Equals("OptionId", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!char.TryParse(optionIdStr, out var optionId))
                throw new Exception($"OptionId '{optionIdStr}' isn't a valid value of part of primary key");

            if (!optionIds.Contains(optionId))
                throw new Exception($"Race kit option '{optionId}' doesn't exist in dependent set");

            string itemIdStr = columns[Array.FindIndex(headers, h => h.Equals("ItemId", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!short.TryParse(itemIdStr, out var itemId))
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
            IEnumerable<int> runnerIds = context.Runners.GetKeysFromSet<Runner, int>();
            IEnumerable<int> charityIds = context.Charities.GetKeysFromSet<Charity, int>();
            IEnumerable<byte> signUpStatusIds = context.SignUpStatuses.GetKeysFromSet<SignUpStatus, byte>();
            IEnumerable<char> raceKitOptionIds = context.RaceKitOptions.GetKeysFromSet<RaceKitOption, char>();

            return File.ReadAllLines(csvMarathonSignUpsFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateMarathonSignUp(column, csvHeaders, runnerIds, charityIds, signUpStatusIds, raceKitOptionIds))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private MarathonSignUp CreateMarathonSignUp(string[] columns, string[] headers, IEnumerable<int> runnerIds, IEnumerable<int> charityIds, IEnumerable<byte> signUpStatusIds, IEnumerable<char> raceKitOptionIds)
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

            string idStr = columns[Array.FindIndex(headers, h => h.Equals("Id", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!int.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity number");

            #endregion

            #region RunnerId

            string runnerIdStr = columns[Array.FindIndex(headers, h => h.Equals("RunnerId", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!int.TryParse(runnerIdStr, out var runnerId))
                throw new Exception($"Runner id '{runnerIdStr}' isn't a valid");

            if (!runnerIds.Contains(runnerId))
                throw new Exception($"Runner with id '{runnerId}' doesn't exist");

            #endregion

            #region RaceKitOptionId

            string raceKitOptionIdStr = columns[Array.FindIndex(headers, h => h.Equals("RaceKitOptionId", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!char.TryParse(raceKitOptionIdStr, out var raceKitOptionId))
                throw new Exception($"Race kit option id '{raceKitOptionIdStr}' isn't a valid");

            if (!raceKitOptionIds.Contains(raceKitOptionId))
                throw new Exception($"Race kit option with id '{raceKitOptionId}' doesn't exist");

            #endregion

            #region SignUpStatusId

            string signUpStatusIdStr = columns[Array.FindIndex(headers, h => h.Equals("SignUpStatusId", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!byte.TryParse(signUpStatusIdStr, out var signUpStatusId))
                throw new Exception($"Sign up status id '{signUpStatusIdStr}' isn't a valid");

            if (!signUpStatusIds.Contains(signUpStatusId))
                throw new Exception($"Sign up status with id '{signUpStatusId}' doesn't exist");

            #endregion

            #region CharityId

            string charityIdStr = columns[Array.FindIndex(headers, h => h.Equals("CharityId", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!int.TryParse(charityIdStr, out var charityId))
                throw new Exception($"Charity id '{charityIdStr}' isn't a valid");

            if (!charityIds.Contains(charityId))
                throw new Exception($"Charity with id '{charityId}' doesn't exist");

            #endregion

            #region SignUpDate

            string signUpDateStr = columns[Array.FindIndex(headers, h => h.Equals("SignUpDate", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!DateTime.TryParse(signUpDateStr, out var signUpDate))
                throw new Exception($"Sign up date '{signUpDateStr}' isn't a valid");

            if (signUpDate.Date.ToUniversalTime() > DateTime.Now.ToUniversalTime())
                throw new Exception("Sign up date is larger than current date");

            #endregion

            #region Cost

            string costStr = columns[Array.FindIndex(headers, h => h.Equals("Cost", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!decimal.TryParse(costStr, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var cost))
                throw new Exception($"Cost '{costStr}' isn't a valid decimal value");

            #endregion

            #region SponsorshipTarget

            string sponsorshipTargetStr = columns[Array.FindIndex(headers, h => h.Equals("SponsorshipTarget", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
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
                SignUpStatusId = signUpStatusId,
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
            IEnumerable<int> signUpIds = context.MarathonSignUps.GetKeysFromSet<MarathonSignUp, int>();

            return File.ReadAllLines(csvSponsorshipsFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateSponsorship(column, csvHeaders, signUpIds))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private Sponsorship CreateSponsorship(string[] columns, string[] headers, IEnumerable<int> signUpIds)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            if (signUpIds == null)
                throw new ArgumentNullException(nameof(signUpIds));

            #region Check required fields

            #region Primary key

            string idStr = columns[Array.FindIndex(headers, h => h.Equals("Id", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!int.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity number");

            #endregion

            #region Name

            string name = columns[Array.FindIndex(headers, h => h.Equals("Name", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name column is empty");

            #endregion

            #region SignUpId

            string signUpIdStr = columns[Array.FindIndex(headers, h => h.Equals("SignUpId", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!int.TryParse(signUpIdStr, out var signUpId))
                throw new Exception($"Sign up id '{signUpIdStr}' isn't a valid");

            if (!signUpIds.Contains(signUpId))
                throw new Exception($"Sign up with id '{signUpId}' doesn't exist");

            #endregion

            #region Amount

            string amountStr = columns[Array.FindIndex(headers, h => h.Equals("Amount", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
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

            string idStr = columns[Array.FindIndex(headers, h => h.Equals("Id", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!byte.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity number");

            #endregion

            #region Name

            string name = columns[Array.FindIndex(headers, h => h.Equals("Name", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name column is empty");

            #endregion

            #region CountryId

            string countryId = columns[Array.FindIndex(headers, h => h.Equals("CountryId", StringComparison.OrdinalIgnoreCase))].TrimQuotes();

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

            int cityIndex = Array.FindIndex(headers, h => h.Equals("City", StringComparison.OrdinalIgnoreCase));
            if (cityIndex > -1)
            {
                string city = columns[cityIndex].TrimQuotes();

                marathon.City = !string.IsNullOrWhiteSpace(city)
                        ? city
                        : throw new Exception("City column in empty");
            }

            #endregion

            #region YearHeld

            int yearHeldIndex = Array.FindIndex(headers, h => h.Equals("YearHeld", StringComparison.OrdinalIgnoreCase));
            if (yearHeldIndex > -1)
            {
                string yearHeldStr = columns[yearHeldIndex].TrimQuotes();
                if (!short.TryParse(yearHeldStr, out var yearHeld))
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

            string id = columns[Array.FindIndex(headers, h => h.Equals("Id", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (string.IsNullOrWhiteSpace(id))
                throw new Exception($"Id '{id}' isn't a valid identity key");

            #endregion

            #region Name

            string name = columns[Array.FindIndex(headers, h => h.Equals("Name", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
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

            string id = columns[Array.FindIndex(headers, h => h.Equals("Id", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (string.IsNullOrWhiteSpace(id))
                throw new Exception($"Id '{id}' isn't a valid identity key");

            #endregion

            #region Name

            string name = columns[Array.FindIndex(headers, h => h.Equals("Name", StringComparison.OrdinalIgnoreCase))].TrimQuotes();

            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name column is empty");

            #endregion

            #region EventTypeId

            string eventTypeId = columns[Array.FindIndex(headers, h => h.Equals("EventTypeId", StringComparison.OrdinalIgnoreCase))].TrimQuotes();

            if (string.IsNullOrWhiteSpace(eventTypeId))
                throw new Exception("EventTypeId column is empty");

            if (!eventTypeIds.Contains(eventTypeId))
                throw new Exception($"Event type with id '{eventTypeId}' doesn't exist");

            #endregion

            #region MarathonId

            string marathonIdStr = columns[Array.FindIndex(headers, h => h.Equals("MarathonId", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
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

            int startDateIndex = Array.FindIndex(headers, h => h.Equals("StartDate", StringComparison.OrdinalIgnoreCase));
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

            int costIndex = Array.FindIndex(headers, h => h.Equals("Cost", StringComparison.OrdinalIgnoreCase));
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

            int maxParticipantsIndex = Array.FindIndex(headers, h => h.Equals("MaxParticipants", StringComparison.OrdinalIgnoreCase));
            if (maxParticipantsIndex > -1)
            {
                string maxParticipantsStr = columns[maxParticipantsIndex].TrimQuotes();
                if (!string.IsNullOrWhiteSpace(maxParticipantsStr))
                {
                    newEvent.MaxParticipants = short.TryParse(maxParticipantsStr, out var maxParticipants)
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
            IEnumerable<int> signUpIds = context.MarathonSignUps.GetKeysFromSet<MarathonSignUp, int>();
            IEnumerable<string> eventIds = context.Events.GetKeysFromSet<Event, string>();

            return File.ReadAllLines(csvSignUpMarathonEventsFile)
                .Skip(1) // skip header row
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .SelectTry(column => CreateSignUpMarathonEvent(column, csvHeaders, signUpIds, eventIds))
                .OnCaughtException(ex => { logger.LogError(ex.Message); return null; })
                .Where(x => x != null);
        }

        private SignUpMarathonEvent CreateSignUpMarathonEvent(string[] columns, string[] headers, IEnumerable<int> signUpIds, IEnumerable<string> eventIds)
        {
            if (columns.Length != headers.Length)
                throw new Exception($"Column count '{columns.Length}' not the same as headers count'{headers.Length}'");

            if (signUpIds == null)
                throw new ArgumentNullException(nameof(signUpIds));

            if (eventIds == null)
                throw new ArgumentNullException(nameof(eventIds));

            #region Check required fields

            #region Primary key

            string idStr = columns[Array.FindIndex(headers, h => h.Equals("Id", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!int.TryParse(idStr, out var id))
                throw new Exception($"Id '{idStr}' isn't a valid identity number");

            #endregion

            #region SignUpId

            string signUpIdStr = columns[Array.FindIndex(headers, h => h.Equals("SignUpId", StringComparison.OrdinalIgnoreCase))].TrimQuotes();
            if (!int.TryParse(signUpIdStr, out var signUpId))
                throw new Exception($"Sign up id '{signUpIdStr}' isn't a valid");

            if (!signUpIds.Contains(signUpId))
                throw new Exception($"Registration with id '{signUpId}' doesn't exist");

            #endregion

            #region EventId

            string eventId = columns[Array.FindIndex(headers, h => h.Equals("EventId", StringComparison.OrdinalIgnoreCase))].TrimQuotes();

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

            int bibNumberIndex = Array.FindIndex(headers, h => h.Equals("BibNumber", StringComparison.OrdinalIgnoreCase));
            if (bibNumberIndex > -1)
            {
                string bibNumberStr = columns[bibNumberIndex].TrimQuotes();
                if (!string.IsNullOrWhiteSpace(bibNumberStr))
                {
                    signUpMarathonEvent.BibNumber = short.TryParse(bibNumberStr, out var bibNumber)
                        ? bibNumber
                        : throw new Exception($"Bib number '{bibNumberStr}' isn't a valid integer value");
                }
            }

            #endregion

            #region Race time

            int raceTimeIndex = Array.FindIndex(headers, h => h.Equals("RaceTime", StringComparison.OrdinalIgnoreCase));
            if (raceTimeIndex > -1)
            {
                string raceTimeStr = columns[raceTimeIndex].TrimQuotes();
                if (!string.IsNullOrWhiteSpace(raceTimeStr))
                {
                    signUpMarathonEvent.RaceTime = int.TryParse(raceTimeStr, out var raceTime)
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
                if (!csvHeaders.Contains(requiredHeader, StringComparer.InvariantCultureIgnoreCase))
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
        private void SeedEnumeration<TEntity, TKey, TEntityEnum>(DbSet<TEntity> repository, IEnumerable<TEntityEnum> items)
            where TEntity : class, IEnumEntity<TKey>, new()
            where TEntityEnum : Enumeration<TKey, TEntity>
        {
            var enumList = items.AsQueryable();

            foreach (var item in enumList.Select(Enumeration<TKey, TEntity>.Projection))
                repository.Add(item);
        }

        /// <summary>
        /// Remove prefix from string
        /// </summary>
        /// <param name="text">Original string</param>
        /// <param name="prefix">Prefix to remove</param>
        private string StripPrefix(string text, string prefix)
        {
            return text.StartsWith(prefix) ? text.Substring(prefix.Length) : text;
        }

        private void SetIdentityInsert(MarathonDbContext context, string tableName, bool enabled)
        {
            context.Database.ExecuteSqlCommand(GetIdentityInsertCommand(tableName, enabled));
        }

        private string GetIdentityInsertCommand(string tableName, bool enabled)
        {
            return $"SET IDENTITY_INSERT dbo.[{tableName}] {(enabled ? "ON" : "OFF")};";
        }
    }

    #endregion
}