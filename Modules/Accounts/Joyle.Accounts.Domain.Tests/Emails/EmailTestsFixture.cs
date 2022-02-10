using Bogus;
using Xunit;

namespace Joyle.Accounts.Domain.Tests.Emails
{
    [CollectionDefinition(nameof(EmailTestesFixtureCollection))]
    public class EmailTestesFixtureCollection : ICollectionFixture<EmailTestsFixture>
    {

    }

    public class EmailTestsFixture
    {
        public string CreateValidEmailAddress()
            => new Faker("pt_BR").Internet.Email();

        public string CreateEmailWithoutAt()
            => CreateValidEmailAddress().Replace("@", "");

        public string CreateEmailWithoutDotCom()
            => CreateValidEmailAddress().Replace(".com", "").Replace(".", "");
    }
}
