using FluentAssertions;
using Joyle.Accounts.Domain.PasswordRecoveries;
using Joyle.Accounts.Domain.PasswordRecoveries.Events;
using Joyle.BuildingBlocks.Domain;
using System;
using Xunit;

namespace Joyle.Accounts.Domain.Tests.PasswordRecoveries
{
    [Collection(nameof(PasswordRecoveryTestsFixtureCollection))]
    public class PasswordRecoveryTests
    {
        private readonly PasswordRecoveryTestsFixture _testsFixture;

        public PasswordRecoveryTests(PasswordRecoveryTestsFixture testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Request Password Recovery, should create a new instance and publish event")]
        [Trait("Category", "Request")]
        public void PasswordRecovery_Request_ShouldCreateNewInstance()
        {
            var email = _testsFixture.CreateFakeEmail();
            var recoveryLink = _testsFixture.CreateFakeUrl();

            var request = PasswordRecovery.Request(email, recoveryLink);

            request.Email.Should().Be(email);
            request.CreationDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(30));
            request.Status.Should().Be(PasswordRecoveryStatus.Requested);
            var passwordRecoveryRequestedEvent = _testsFixture.AssertPublishedDomainEvent<PasswordRecoveryRequestedDomainEvent>(request);
            passwordRecoveryRequestedEvent.Email.Should().Be(email);
        }

        [Fact(DisplayName = "Recover Password, should update status, RecoveryDate and publish event")]
        [Trait("Category", "Recover")]
        public void PasswordRecovery_Recover_ShouldUpdateStatus()
        {
            var passwordRecovery = _testsFixture.CreateFakePasswordRecovery();
            var newPassword = _testsFixture.CreateFakePassword();

            passwordRecovery.Recover(newPassword);

            passwordRecovery.Status.Should().Be(PasswordRecoveryStatus.Recovered);
            passwordRecovery.RecoveryDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(30));
            var passwordRecoveryRecoveredEvent = _testsFixture.AssertPublishedDomainEvent<PasswordRecoveredDomainEvent>(passwordRecovery);
            passwordRecoveryRecoveredEvent.Password.Should().Be(newPassword);
        }

        [Fact(DisplayName = "Recover Password that was already recover, should throw and exception")]
        [Trait("Category", "Recover")]
        public void PasswordRecovery_Recover_ShouldThrowAnException()
        {
            var passwordRecovery = _testsFixture.CreateFakePasswordRecovery();
            var newPassword = _testsFixture.CreateFakePassword();
            passwordRecovery.Recover(newPassword);

            Action action = () => passwordRecovery.Recover(newPassword);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("This password recovery was already used");
        }
    }
}
