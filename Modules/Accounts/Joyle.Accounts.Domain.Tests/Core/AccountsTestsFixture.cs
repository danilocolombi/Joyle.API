using Bogus;

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
    }
}
