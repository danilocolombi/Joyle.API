using Joyle.Accounts.Domain.PasswordRecoveries;
using Joyle.Accounts.Domain.Tests.Core;
using Xunit;

namespace Joyle.Accounts.Domain.Tests.PasswordRecoveries
{
    [CollectionDefinition(nameof(PasswordRecoveryTestsFixtureCollection))]
    public class PasswordRecoveryTestsFixtureCollection : ICollectionFixture<PasswordRecoveryTestsFixture>
    {

    }

    public class PasswordRecoveryTestsFixture : AccountsTestsFixture
    {
        public PasswordRecovery CreateFakePasswordRecovery()
        {
            return PasswordRecovery.Request(
                CreateFakeEmail(),
                CreateFakeUrl());
        }
    }
}
