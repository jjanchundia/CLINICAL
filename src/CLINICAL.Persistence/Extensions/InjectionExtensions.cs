using CLINICAL.Application.Interface;
using CLINICAL.Persistence.Context;
using CLINICAL.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CLINICAL.Persistence.Extensions
{
    public static class InjectionExtensions
    {
        //Configuramos context para que se configure como ciclo de vida Singleton
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            //Ciclo de vida singleton
            services.AddSingleton<ApplicationDbContext>();
            services.AddScoped<IAnalisisRepository, AnalisisRepository>();

            return services;
        }
    }
}