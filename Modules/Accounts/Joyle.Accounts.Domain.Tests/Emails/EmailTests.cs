using FluentAssertions;
using Joyle.BuildingBlocks.Domain;
using System;
using Xunit;

namespace Joyle.Accounts.Domain.Tests.Emails
{
    [Collection(nameof(EmailTestesFixtureCollection))]
    public class EmailTests
    {
        private readonly EmailTestsFixture _testsFixture;

        public EmailTests(EmailTestsFixture testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Validate valid email, should return true")]
        [Trait("Category", "Validate Email")]
        public void Email_Validate_ShouldReturnTrue()
        {
            var email = _testsFixture.CreateValidEmailAddress();

            var result = Email.Validate(email);

            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Validate empty email, should return false")]
        [Trait("Category", "Validate Email")]
        public void Email_Validate_EmptyEmail_ShouldReturnFalse()
        {
            var email = "";

            var result = Email.Validate(email);

            result.Should().BeFalse();
        }

        [Fact(DisplayName = "Validate email without at, should return false")]
        [Trait("Category", "Validate Email")]
        public void Email_Validate_EmailWithoutAt_ShouldReturnFalse()
        {
            var email = _testsFixture.CreateEmailWithoutAt();

            var result = Email.Validate(email);

            result.Should().BeFalse();
        }

        [Fact(DisplayName = "Validate email without .com, should return false")]
        [Trait("Category", "Validate Email")]
        public void Email_Validate_EmailWithoutDotCom_ShouldReturnFalse()
        {
            var email = _testsFixture.CreateEmailWithoutDotCom();

            var result = Email.Validate(email);

            result.Should().BeFalse();
        }

        [Fact(DisplayName = "Create valid email, should return new instance")]
        [Trait("Category", "Create Email")]
        public void Email_Create__ShouldReturnNewInstance()
        {
            var address = _testsFixture.CreateValidEmailAddress();

            var email = new Email(address);

            email.Address.Should().Be(address);
        }

        [Fact(DisplayName = "Create invalid email, should return throw an exception")]
        [Trait("Category", "Create Email")]
        public void Email_Create__ShouldThrowAnException()
        {
            var address = _testsFixture.CreateEmailWithoutAt();

            Action action = () => new Email(address);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage(Email.Specifications);
        }
    }
}
