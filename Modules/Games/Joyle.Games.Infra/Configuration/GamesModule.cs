using Autofac;
using FluentValidation;
using Joyle.Games.Application.Cardashians.CreateCardashian;
using Joyle.Games.Domain.Cardashians.Interfaces;
using Joyle.Games.Infra.Data.Cardashians;
using MediatR;
using System.Reflection;

namespace Joyle.Games.Infra.Configuration
{
    public class GamesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(CreateCardashianCommand).GetTypeInfo().Assembly)
               .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(CreateCardashianCommandValidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

            builder.RegisterType<CardashianRepository>()
               .As<ICardashianRepository>()
               .InstancePerLifetimeScope();
        }
    }
}
