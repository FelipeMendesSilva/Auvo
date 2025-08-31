using Auvo.GloboClima.Domain.Interfaces;
using Auvo.GloboClima.Infra.Data.Adapters;
using Auvo.GloboClima.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auvo.GloboClima.Infra.Data.IoC
{
    public static class RegisterInfraServicesExtension
    {
        public static void RegisterInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 43))));

            services.AddScoped<ICountryInfoAdapter, CountryInfoAdapter>();

        }
    }
}
