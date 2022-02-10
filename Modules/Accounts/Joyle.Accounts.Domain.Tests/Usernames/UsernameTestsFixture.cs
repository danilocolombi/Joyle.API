using Bogus;
using Xunit;

namespace Joyle.Accounts.Domain.Tests.Usernames
{
    [CollectionDefinition(nameof(UsernameTestsFixture))]
    public class UsernameTestsFixtureCollection : ICollectionFixture<UsernameTestsFixture>
    {

    }

    public class UsernameTestsFixture
    {
        public string CreateValidUsername()
            => new Faker("pt_BR").Internet.UserName();

        public string CreateUsernameWithSpace()
        {
            var username = CreateValidUsername();
            var posicaoAleatoria = new Faker().Random.Int(0, username.Length);

            return username.Insert(posicaoAleatoria, " ");
        }

        public string CreateShortUsername()
        {
            var username = CreateValidUsername();

            for (int i = username.Length; i >= Username.MinLength; i--)
                username = username.Remove(i - 1);

            return username;
        }

        public string CreateLongUsername()
        {
            var username = CreateValidUsername();

            for (int i = username.Length; i <= Username.MaxLength; i++)
                username = username + $"{new Faker().Random.Char()}"; 

            return username;
        }
    }
}
