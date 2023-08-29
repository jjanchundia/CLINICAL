using CLINICAL.Application.UseCase.Commonds.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CLINICAL.Application.UseCase.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services)
        {
            //Forma de registrar Assembly de nueva actualización de MediatR
            services.AddMediatR(x=> x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Se inyecta servicio de FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //Se inyecta servicio de validacion para usar el Middleware
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}