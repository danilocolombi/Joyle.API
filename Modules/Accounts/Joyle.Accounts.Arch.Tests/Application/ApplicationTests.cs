using FluentValidation;
using Joyle.Accounts.Arch.Tests.Core;
using Joyle.BuildingBlocks.Application.Messages;
using NetArchTest.Rules;
using Xunit;

namespace Joyle.Accounts.Arch.Tests.Application
{
    public class ApplicationTests : TestsBase
    {

        [Fact(DisplayName = "Assure all commands are immutable")]
        [Trait("Category", "Application")]
        public void Commands_ShouldBeImmutable()
        {
            var types = Types.InAssembly(_applicationAssembly)
                .That()
                .Inherit(typeof(CommandBase))
                .Or()
                .Inherit(typeof(CommandBase<>))
                .GetTypes();

            AssertAreImmutable(types);
        }

        [Fact(DisplayName = "Assure Command Handlers have name ending in CommandHandler")]
        [Trait("Category", "Application")]
        public void CommandHandler_ShouldHaveNameEndingIn_CommandHandler()
        {
            var result = Types.InAssembly(_applicationAssembly)
                 .That()
                 .ImplementInterface(typeof(ICommandHandler<>))
                 .Or()
                 .ImplementInterface(typeof(ICommandHandler<,>))
                 .Should()
                 .HaveNameEndingWith("CommandHandler")
                 .GetResult();

            Assert.Null(result.FailingTypes);
        }

        [Fact(DisplayName = "Assure Validators have name ending in Validator")]
        [Trait("Category", "Application")]
        public void Validator_ShouldHaveNameEndingIn_Validator()
        {
            var result = Types.InAssembly(_applicationAssembly)
                 .That()
                 .Inherit(typeof(AbstractValidator<>))
                 .Should()
                 .HaveNameEndingWith("Validator")
                 .GetResult();

            Assert.Null(result.FailingTypes);
        }

        [Fact(DisplayName = "Assure Command Handlers are not public")]
        [Trait("Category", "Application")]
        public void CommandHandler_ShouldNotBePublic()
        {
            var types = Types.InAssembly(_applicationAssembly)
               .That()
                   .ImplementInterface(typeof(ICommandHandler<>))
                       .Or()
                   .ImplementInterface(typeof(ICommandHandler<,>))
               .Should().NotBePublic().GetResult().FailingTypes;

            Assert.Null(types);
        }
    }
}
