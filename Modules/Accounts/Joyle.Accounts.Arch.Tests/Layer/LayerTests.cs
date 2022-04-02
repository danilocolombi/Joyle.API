using Joyle.Accounts.Arch.Tests.Core;
using NetArchTest.Rules;
using Xunit;

namespace Joyle.Accounts.Arch.Tests.Layer
{
    public class LayerTests : TestsBase
    {
        [Fact(DisplayName = "Assert domain layer doesnt depend on application layer")]
        [Trait("Categoria", "Layer")]
        public void DomainLayer_DoesntDependOn_ApplicationLayer()
        {
            var result = Types.InAssembly(_domainAssembly)
                .Should()
                .NotHaveDependencyOn(_applicationAssembly.GetName().Name)
                .GetResult();

            Assert.Null(result.FailingTypeNames);
        }

        [Fact(DisplayName = "Assert domain layer doesnt depend on infra layer")]
        [Trait("Categoria", "Layer")]
        public void DomainLayer_DoesntDependOn_InfraLayer()
        {
            var result = Types.InAssembly(_domainAssembly)
                .Should()
                .NotHaveDependencyOn(_infraAssembly.GetName().Name)
                .GetResult();

            Assert.Null(result.FailingTypeNames);
        }


        [Fact(DisplayName = "Assert application layer doesnt depend on infra layer")]
        [Trait("Categoria", "Layer")]
        public void ApplicationLayer_DoesntDependOn_InfraLayer()
        {
            var result = Types.InAssembly(_applicationAssembly)
                .Should()
                .NotHaveDependencyOn(_infraAssembly.GetName().Name)
                .GetResult();

            Assert.Null(result.FailingTypeNames);
        }
    }
}
