using Xunit;
using FluentValidation.TestHelper;
using Marathon.Application.Users.Commands.SignIn;

namespace Marathon.Application.Tests.Users.Validators
{
    /// <summary>
    /// Unit test module for <see cref="SignInCommandValidator"/>
    /// </summary>
    public class SignInCommandValidatorTests
    {
        private readonly SignInCommandValidator _validator;

        public SignInCommandValidatorTests()
        {
            _validator = new SignInCommandValidator();
        }

        [Fact]
        public void ShouldHaveErrorWhenEmailIsEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Email, string.Empty);
        }

        [Fact]
        public void ShouldHaveErrorIfEntryStringNotMatchEmailRegex()
        {
            const string wrongEmail = "qwerty12345";

            _validator.ShouldHaveValidationErrorFor(x => x.Email, wrongEmail);
        }

        [Fact]
        public void ShouldHaveErrorWhenPasswordIsEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Password, string.Empty);
        }
    }
}
