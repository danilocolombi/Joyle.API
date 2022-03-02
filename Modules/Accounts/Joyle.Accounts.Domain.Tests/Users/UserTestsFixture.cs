using Joyle.Accounts.Domain.Tests.Core;
using Joyle.Accounts.Domain.Users;
using System;
using Xunit;

namespace Joyle.Accounts.Domain.Tests.Users
{
    [CollectionDefinition(nameof(UserTestsFixtureCollection))]
    public class UserTestsFixtureCollection : ICollectionFixture<UserTestsFixture>
    {

    }

    public class UserTestsFixture : AccountsTestsFixture
    {
        public User CreateFakeUser()
        {
            return User.CreateUserFromRegistration(
                Guid.NewGuid(),
                CreateFakeUsername(),
                CreateFakeFullName(),
                CreateFakeEmail(),
                CreateFakePassword());
        }
    }
}
