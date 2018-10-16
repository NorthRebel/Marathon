using System;
using Marathon.Domain.Entities;
using MediatR;

namespace Marathon.Application.Users.Commands.Register
{
    /// <summary>
    /// Command requirements to register <see cref="Runner"/>
    /// </summary>
    public sealed class RegisterRunnerCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long GenderId { get; set; }
        public long CountryId { get; set; }
        public byte[] Photo { get; set; }
    }
}
