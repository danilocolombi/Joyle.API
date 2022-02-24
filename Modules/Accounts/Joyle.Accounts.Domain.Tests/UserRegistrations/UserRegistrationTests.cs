using FluentAssertions;
using Joyle.Accounts.Domain.UserRegistrations;
using Joyle.Accounts.Domain.UserRegistrations.Events;
using Joyle.BuildingBlocks.Domain;
using System;
using Xunit;

namespace Joyle.Accounts.Domain.Tests.UserRegistrations
{
    [Collection(nameof(UserRegistrationTestsFixtureCollection))]
    public class UserRegistrationTests
    {
        private readonly UserRegistrationTestsFixture _testesFixture;

        public UserRegistrationTests(UserRegistrationTestsFixture testesFixture)
        {
            _testesFixture = testesFixture;
        }

        [Fact(DisplayName = "Register new user, should create a new instance of UserRegistration correctly and publish event")]
        [Trait("Category", "Register New User")]
        public void UserRegistration_RegisterNewUser_ShouldCreateNewInstanceAndPublishEvent()
        {
            var userName = _testesFixture.CreateFakeUsername();
            var fullName = _testesFixture.CreateFakeFullName();
            var email = _testesFixture.CreateFakeEmail();
            var password = _testesFixture.CreateFakePassword();
            var confirmationLink = _testesFixture.CreateFakeUrl();
            var usersWithThisLogin = 0;

            var newUserRegistration = UserRegistration.RegisterNewUser(userName, fullName, email, password, usersWithThisLogin, confirmationLink);

            newUserRegistration.Username.Should().Be(userName);
            newUserRegistration.FullName.Should().Be(fullName);
            var userRegisteredDomainEvent = _testesFixture.AssertPublishedDomainEvent<NewUserRegisteredDomainEvent>(newUserRegistration);
            userRegisteredDomainEvent.Email.Should().Be(email);
        }

        [Fact(DisplayName = "Register new user with a username that already exists, should throw an exception")]
        [Trait("Category", "Register New User")]
        public void UserRegistration_RegisterNewUser_ShouldThrowAnException()
        {
            var userName = _testesFixture.CreateFakeUsername();
            var fullName = _testesFixture.CreateFakeFullName();
            var email = _testesFixture.CreateFakeEmail();
            var password = _testesFixture.CreateFakePassword();
            var confirmationLink = _testesFixture.CreateFakeUrl();
            var usersWithThisLogin = 1;

            Action action = () => UserRegistration.RegisterNewUser(userName, fullName, email, password, usersWithThisLogin, confirmationLink);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("Username must be unique");
        }

        [Fact(DisplayName = "Confirm user registration, should update status and confirmation date, and publish event")]
        [Trait("Category", "Confirm")]
        public void UserRegistration_Confirm_ShouldConfirm()
        {
            var userRegistration = _testesFixture.CreateFakeUserRegistration();

            userRegistration.Confirm();

            userRegistration.Status.Value.Should().Be(UserRegistrationStatus.Confirmed.Value);
            userRegistration.ConfirmationDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(10));
            var userRegisteredDomainEvent = _testesFixture.AssertPublishedDomainEvent<UserRegistrationConfirmedDomainEvent>(userRegistration);
            userRegisteredDomainEvent.UserRegistration.Should().Be(userRegistration);
        }

        [Fact(DisplayName = "Confirm user registration that is already confirmed")]
        [Trait("Category", "Confirm")]
        public void UserRegistration_Confirm_ShouldThrowAnException_RegistrationConfirmed()
        {
            var userRegistration = _testesFixture.CreateFakeUserRegistration();
            userRegistration.Confirm();

            Action action = () => userRegistration.Confirm();

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("User already confirmed");
        }
    }
}
