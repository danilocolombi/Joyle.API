using Joyle.Accounts.Arch.Tests.Core;
using Joyle.BuildingBlocks.Domain;
using NetArchTest.Rules;
using Xunit;

namespace Joyle.Accounts.Arch.Tests.Domain
{
    public class DomainTests : TestsBase
    {
        [Fact(DisplayName = "Assure all domain events are immutable")]
        [Trait("Category", "Domain")]
        public void DomainEvents_ShouldBeImmutable()
        {
            var types = Types.InAssembly(_domainAssembly)
                .That()
                .Inherit(typeof(DomainEvent))
                .GetTypes();

            AssertAreImmutable(types);
        }

        [Fact(DisplayName = "Assure Domain Events have name ending in DomainEvent")]
        [Trait("Category", "Domain")]
        public void DomainEvent_ShouldHaveNameEndingIn_DomainEvent()
        {
            var result = Types.InAssembly(_domainAssembly)
                 .That()
                 .Inherit(typeof(DomainEvent))
                 .Should()
                 .HaveNameEndingWith("DomainEvent")
                 .GetResult();

            Assert.Null(result.FailingTypes);
        }

        [Fact(DisplayName = "Assure all entities don't have public setters")]
        [Trait("Category", "Domain")]
        public void Entities_DontHave_PublicSetters()
        {
            var types = Types.InAssembly(_domainAssembly)
                .That()
                .Inherit(typeof(Entity))
                .GetTypes();

            AssertDontHavePublicSetters(types);
        }
    }
}
