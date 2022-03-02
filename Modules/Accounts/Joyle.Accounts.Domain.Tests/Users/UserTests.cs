using FluentAssertions;
using System;
using Xunit;

namespace Joyle.Accounts.Domain.Tests.Users
{
    [Collection(nameof(UserTestsFixtureCollection))]
    public class UserTests
    {
        private readonly UserTestsFixture _testsFixture;

        public UserTests(UserTestsFixture testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Inactivate User, should change IsActive to false and set InactivationDate")]
        [Trait("Category", "Inactive")]
        public void User_InactivateUser_ShouldChangeIsActive()
        {
            var user = _testsFixture.CreateFakeUser();

            user.Inactivate();

            user.IsActive.Should().BeFalse();
            user.InactivationDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(10));
        }
    }
}
