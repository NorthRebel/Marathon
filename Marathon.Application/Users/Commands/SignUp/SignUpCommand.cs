using System;
using Marathon.Domain.Entities;
using MediatR;

namespace Marathon.Application.Users.Commands.SignUp
{
    /// <summary>
    /// Command requirements to sign up <see cref="Runner"/> to marathon
    /// </summary>
    public sealed class SignUpCommand : IRequest
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
