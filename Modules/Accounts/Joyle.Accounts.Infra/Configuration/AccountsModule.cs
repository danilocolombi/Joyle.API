using Autofac;
using FluentValidation;
using Joyle.Accounts.Application.UserRegistrations.RegisterNewUser;
using Joyle.Accounts.Domain.PasswordRecoveries.Interfaces;
using Joyle.Accounts.Domain.UserRegistrations.Interfaces;
using Joyle.Accounts.Domain.Users.Interfaces;
using Joyle.Accounts.Infra.Data.PasswordRecoveries;
using Joyle.Accounts.Infra.Data.UserRegistrations;
using Joyle.Accounts.Infra.Data.Users;
using MediatR;
using System.Reflection;

namespace Joyle.Accounts.Infra.Configuration
{
    public class AccountsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(RegisterNewUserCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(NewUserRegisteredNotification).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(INotificationHandler<>));

            builder.RegisterAssemblyTypes(typeof(RegisterNewUserCommandValidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

            builder.RegisterType<UserRegistrationRepository>()
                .As<IUserRegistrationRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PasswordRecoveryRepository>()
                .As<IPasswordRecoveryRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
