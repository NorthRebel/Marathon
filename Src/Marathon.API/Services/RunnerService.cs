using System;
using Marathon.Persistence;
using System.Threading.Tasks;
using Marathon.Domain.Entities;
using Marathon.API.Models.Runner;
using Microsoft.EntityFrameworkCore;

namespace Marathon.API.Services
{
    public class RunnerService : IRunnerService
    {
        private readonly MarathonDbContext _context;

        public RunnerService(MarathonDbContext context)
        {
            _context = context;
        }

        public async Task<int> SignUpAsync(RunnerSignUpCredentials credentials)
        {
            if (IsUserRunner(credentials.UserId).Result)
                throw new Exception($"User with id {credentials.UserId} is already signed up as runner");

            var newRunner = CreateRunner(credentials);

            int id = 0;

            await SaveRunner(newRunner).ContinueWith(r => id = newRunner.Id);

            return id;
        }

#pragma warning disable 1998
        public async Task<int> GetId(int userId)
#pragma warning restore 1998
        {
            Task<Runner> runner = _context.Runners.SingleOrDefaultAsync(r => r.UserId == userId);

            runner.Wait();

            Runner result = runner.Result;

            if (result != null)
                return result.Id;

            return default(int);
        }

        private Task SaveRunner(Runner runner)
        {
            _context.Runners.Add(runner);
            return _context.SaveChangesAsync();
        }

        private Runner CreateRunner(RunnerSignUpCredentials credentials)
        {
            return new Runner
            {
                UserId = credentials.UserId,
                GenderId = credentials.GenderId,
                DateOfBirth = credentials.DateOfBirth,
                CountryId = credentials.CountryId,
                Photo = credentials.Photo
            };
        }

        private async Task<bool> IsUserRunner(int userId)
        {
            return await _context.Runners.SingleOrDefaultAsync(r => r.UserId == userId) != null;
        }
    }
}
