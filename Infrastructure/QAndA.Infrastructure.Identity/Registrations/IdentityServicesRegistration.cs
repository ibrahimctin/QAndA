using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using QAndA.Domain.Application.Contracts.Identity;
using QAndA.Domain.Entities.IdentityEntities;
using QAndA.Infrastructure.Extensions;
using QAndA.Infrastructure.Identity.Services;

namespace QAndA.Infrastructure.Identity.Registrations
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {



            services.TryAddScoped<IGenerateJwtToken, GenerateJwtToken>();
            services.TryAddTransient<ICurrentUserService, CurrentUserService>();
           


            return services;
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
            }).AddRoleManager<RoleManager<IdentityRole>>()
             .AddEntityFrameworkStores<AppDbContext>()
          .AddDefaultTokenProviders();
        }
    }
}
