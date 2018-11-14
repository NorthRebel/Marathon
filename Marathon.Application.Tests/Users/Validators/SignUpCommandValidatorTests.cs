using System;
using FluentValidation.TestHelper;
using Marathon.Application.Users.Commands.SignUp;
using Xunit;

namespace Marathon.Application.Tests.Users.Validators
{
    /// <summary>
    /// Unit test module for <see cref="SignUpCommandValidator"/>
    /// </summary>
    public class SignUpCommandValidatorTests
    {
        private SignUpCommandValidator _validator;

        public SignUpCommandValidatorTests()
        {
            _validator = new SignUpCommandValidator();
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

        [Fact]
        public void ShouldHaveErrorIfPasswordLengthIsLowerThanSixSymbols()
        {
            const string smallPassword = "HeLL@";

            _validator.ShouldHaveValidationErrorFor(x => x.Password, smallPassword);
        }

        [Fact]
        public void ShouldHaveErrorIfPasswordNoHaveOneUppercaseLetter()
        {
            const string lowercasePassword = "hello-world";

            _validator.ShouldHaveValidationErrorFor(x => x.Password, lowercasePassword);
        }

        //[Fact]
        //public void ShouldHaveErrorIfPasswordNoHaveOneDigit()
        //{
        //    const string passWithoutSpecialSymbols = "Helloworld";

        //    _validator.ShouldHaveValidationErrorFor(x => x.Password, passWithoutSpecialSymbols);
        //}

        [Fact]
        public void ShouldHaveErrorIfPasswordNoHaveSpecialSymbols()
        {
            const string passWithoutSpecialSymbols = "Hell0-world";

            _validator.ShouldHaveValidationErrorFor(x => x.Password, passWithoutSpecialSymbols);
        }
        
        [Fact]
        public void PasswordWithPassAllCriteria()
        {
            const string rightPassword = "Hell0^W@r1d";

            _validator.ShouldNotHaveValidationErrorFor(x => x.Password, rightPassword);
        }

        [Fact]
        public void ShouldHaveErrorIfAgeIsLowerThan10()
        {
            var dateOfBirth = new DateTime(2010, 10, 25);

            _validator.ShouldHaveValidationErrorFor(x => x.DateOfBirth, dateOfBirth);
        }

        [Fact]
        public void ShouldHaveErrorWhenFirstNameIsEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.FirstName, string.Empty);
        }

        [Fact]
        public void ShouldHaveErrorWhenLastNameIsEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.LastName, string.Empty);
        }

        [Fact]
        public void ShouldHaveErrorWhenPhotoIsNotLoaded()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Photo, new byte[0]);
        }
    }
}
