using System;
using System.Linq;
using Marathon.Persistence;
using Marathon.Domain.Entities;
using Marathon.API.Models.Runner;
using Marathon.API.Repositories.Interfaces;

namespace Marathon.API.Repositories
{
    internal class RunnerRepository : IRunnerRepository
    {
        private readonly MarathonDbContext _context;

        public RunnerRepository(MarathonDbContext context)
        {
            _context = context;
        }

        public uint SignUp(RunnerSignUpCredentials credentials)
        {
            if (IsUserRunner(credentials.UserId))
                throw new Exception($"User with id {credentials.UserId} is already signed up as runner");

            var newRunner = CreateRunner(credentials);
            
            SaveRunner(newRunner);

            return newRunner.Id;
        }

        private void SaveRunner(Runner runner)
        {
            _context.Runners.Add(runner);
            _context.SaveChanges();
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

        private bool IsUserRunner(uint userId)
        {
            return _context.Runners.SingleOrDefault(r => r.UserId == userId) != null;
        }
    }
}
