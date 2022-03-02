using Autofac;
using Joyle.API.Configuration.Authentication.Services;
using Joyle.BuildingBlocks.Application.Data;
using Joyle.BuildingBlocks.Application.Decorators;
using Joyle.BuildingBlocks.Application.Emails;
using Joyle.BuildingBlocks.Application.Mediator;
using Joyle.BuildingBlocks.Infra.Data;
using Joyle.BuildingBlocks.Infra.Emails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Joyle.API.Configuration
{
    public class ApplicationModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ApplicationModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<HttpContextAccessor>()
                .As<IHttpContextAccessor>()
                .SingleInstance();

            builder.RegisterType<AspNetUser>()
                .As<IAspNetUser>()
                .InstancePerLifetimeScope();

            builder.RegisterType<JwtTokenGeneratorService>()
                .As<IJwtTokenGeneratorService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MediatorHandler>()
                .As<IMediatorHandler>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EmailSender>()
                .As<IEmailSender>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SqlConnectionFactory>()
             .As<ISqlConnectionFactory>()
             .WithParameter("connectionString", _configuration.GetConnectionString("DefaultConnection"));

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            builder.RegisterGeneric(typeof(CommandValidationHandlerDecorator<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
