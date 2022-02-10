using FluentAssertions;
using Joyle.BuildingBlocks.Domain;
using System;
using Xunit;

namespace Joyle.Accounts.Domain.Tests.Usernames
{
    [Collection(nameof(UsernameTestsFixture))]
    public class UsernameTests
    {
        private readonly UsernameTestsFixture _testsFixture;

        public UsernameTests(UsernameTestsFixture testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Validate valid username, should return true")]
        [Trait("Category", "Validate Username")]
        public void Username_Validate_ShouldReturnTrue()
        {
            var username = _testsFixture.CreateValidUsername();

            var result = Username.Validate(username);

            result.Should().BeTrue();
        }


        [Fact(DisplayName = "Validate empty username, should return false")]
        [Trait("Category", "Validate Username")]
        public void Username_Validate_EmptyUsername_ShouldReturnFalse()
        {
            var username = "";

            var result = Username.Validate(username);

            result.Should().BeFalse();
        }

        [Fact(DisplayName = "Validate username with space, should return false")]
        [Trait("Category", "Validate Username")]
        public void Username_Validate_UsernameWithSpace_ShouldReturnFalse()
        {
            var username = _testsFixture.CreateUsernameWithSpace();

            var result = Username.Validate(username);

            result.Should().BeFalse();
        }

        [Fact(DisplayName = "Validate too short a username, should return false")]
        [Trait("Category", "Validate Username")]
        public void Username_Validate_TooShortAUsername_ShouldReturnFalse()
        {
            var username = _testsFixture.CreateShortUsername();

            var result = Username.Validate(username);

            result.Should().BeFalse();
        }


        [Fact(DisplayName = "Validate too long a username, should return false")]
        [Trait("Category", "Validate Username")]
        public void Username_Validate_TooLongAUsername_ShouldReturnFalse()
        {
            var username = _testsFixture.CreateLongUsername();

            var result = Username.Validate(username);

            result.Should().BeFalse();
        }

        [Fact(DisplayName = "Create valid username, should return new instance")]
        [Trait("Category", "Create Username")]
        public void Username_Create__ShouldReturnNewInstance()
        {
            var validUsername = _testsFixture.CreateValidUsername();

            var username = new Username(validUsername);

            username.Value.Should().Be(validUsername);
        }

        [Fact(DisplayName = "Create invalid username, should return throw an exception")]
        [Trait("Category", "Create Username")]
        public void Username_Create__ShouldThrowAnException()
        {
            var username = _testsFixture.CreateUsernameWithSpace();

            Action action = () => new Username(username);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage(Username.Specifications);
        }
    }
}
