using Bogus;
using Joyle.Accounts.Domain.Tests.Core;
using Joyle.Accounts.Domain.UserRegistrations;
using Joyle.BuildingBlocks.Domain;
using System;
using System.Linq;
using Xunit;

namespace Joyle.Accounts.Domain.Tests.UserRegistrations
{
    [CollectionDefinition(nameof(UserRegistrationTestsFixtureCollection))]
    public class UserRegistrationTestsFixtureCollection: ICollectionFixture<UserRegistrationTestsFixture>
    {

    }

    public class UserRegistrationTestsFixture: AccountsTestsFixture
    {
        public UserRegistration CreateFakeUserRegistration()
        {
            return UserRegistration.RegisterNewUser(
                CreateFakeUsername(),
                CreateFakeFullName(),
                CreateFakeEmail(),
                CreateFakePassword(),
                usersWithThisLoginCounter: 0,
                CreateFakeUrl());
        }

        public string CreateFakeUrl()
            => new Faker().Internet.Url();

        public T AssertPublishedDomainEvent<T>(Entity entity) where T : DomainEvent
        {
            var domainEvent = entity?.domainEvents.FirstOrDefault(e => e is T);

            if (domainEvent == null)
                throw new Exception($"The event {nameof(T)} wasn't published");

            return (T)domainEvent;
        }
    }
}
