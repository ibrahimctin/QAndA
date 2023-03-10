using MediatR;
using Microsoft.Extensions.DependencyInjection;
using QAndA.Domain.Application.Profiles;
using System.Reflection;

namespace QAndA.Domain.Application.Registrations
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
