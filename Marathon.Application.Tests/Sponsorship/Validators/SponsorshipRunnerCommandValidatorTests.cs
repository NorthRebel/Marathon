using Xunit;
using System;
using FluentValidation.TestHelper;
using Marathon.Application.Sponsorship.Commands.SponsorshipRunner;

namespace Marathon.Application.Tests.Sponsorship.Validators
{
    /// <summary>
    /// Unit test module for <see cref="SponsorshipRunnerCommandValidator"/>
    /// </summary>
    public class SponsorshipRunnerCommandValidatorTests
    {
        private readonly SponsorshipRunnerCommandValidator _validator;

        public SponsorshipRunnerCommandValidatorTests()
        {
            _validator = new SponsorshipRunnerCommandValidator();
        }

        [Fact]
        public void ShouldHaveErrorIfSponsorNameIsEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.SponsorName, string.Empty);
        }

        [Fact]
        public void ShouldHaveErrorIfRunnerNotSelected()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.RunnerMarathonSignUpId, default(long));
        }

        [Fact]
        private void ShouldHaveErrorWhenSponsorshipAmountIsLowerThanZero()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Amount, Decimal.MinusOne);
        }
    }
}
