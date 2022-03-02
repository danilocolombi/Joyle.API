﻿using FluentAssertions;
using Joyle.BuildingBlocks.Domain;
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

        [Fact(DisplayName = "Change Username, should update Username")]
        [Trait("Category", "Change Username")]
        public void User_ChangeUsername_ShouldChangeUpdateUsername()
        {
            var user = _testsFixture.CreateFakeUser();
            var newUsername = _testsFixture.CreateFakeUsername();

            user.ChangeUsername(newUsername, usersWithThisUsernameCounter: 0);

            user.Username.Should().Be(newUsername);
        }

        [Fact(DisplayName = "Change Username to a username that already exists, should throw an exception")]
        [Trait("Category", "Change Username")]
        public void User_ChangeUsername_ShouldThrowAnException()
        {
            var user = _testsFixture.CreateFakeUser();
            var newUsername = _testsFixture.CreateFakeUsername();
            var usersWithThisUsernameCounter = 1;

            Action action = () => user.ChangeUsername(newUsername, usersWithThisUsernameCounter);

            action.Should().Throw<BusinessRuleValidationException>().WithMessage("Username must be unique");
        }

        [Fact(DisplayName = "Change Username passing the same username that already belongs to the user")]
        [Trait("Category", "Change Username")]
        public void User_ChangeUsername_ShouldntDoAnything()
        {
            var user = _testsFixture.CreateFakeUser();
            var newUsername = user.Username;

           user.ChangeUsername(newUsername, usersWithThisUsernameCounter: 0);
        }
    }
}
