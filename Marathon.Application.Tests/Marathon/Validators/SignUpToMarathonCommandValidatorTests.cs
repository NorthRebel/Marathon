using Xunit;
using System;
using FluentValidation.TestHelper;
using Marathon.Application.Marathon.Commands.SignUpToMarathon;

namespace Marathon.Application.Tests.Marathon.Validators
{
    /// <summary>
    /// Unit test module for <see cref="SignUpToMarathonCommandValidator"/>
    /// </summary>
    public class SignUpToMarathonCommandValidatorTests
    {
        private readonly SignUpToMarathonCommandValidator _validator;

        public SignUpToMarathonCommandValidatorTests()
        {
            _validator = new SignUpToMarathonCommandValidator();
        }

        [Fact]
        public void ShouldHaveErrorWhenEventTypesNotSelected()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.EventTypeIds, new string[0]);
        }

        // TODO: Very strange test result
        //[Fact]
        //private void ShouldHaveErrorWhenSponsorshipTargetIsLowerThanZero()
        //{
        //    _validator.ShouldHaveValidationErrorFor(x => x.SponsorshipTarget, Decimal.MinusOne);
        //}
    }
}
