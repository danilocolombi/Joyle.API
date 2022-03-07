using Bogus;
using Joyle.BuildingBlocks.Domain;
using System;
using System.Linq;

namespace Joyle.Accounts.Domain.Tests.Core
{
    public abstract class AccountsTestsFixture
    {
        public Username CreateFakeUsername()
          => new Username(new Faker().Internet.UserName());

        public string CreateFakeFullName()
            => new Faker().Person.FullName;

        public Email CreateFakeEmail()
           => new Email(new Faker().Internet.Email());

        public string CreateFakePassword()
            => new Faker().Internet.Password();

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
