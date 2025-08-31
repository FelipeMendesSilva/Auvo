

using Auvo.GloboClima.Application.Interfaces;
using Auvo.GloboClima.Application.Services;
using Auvo.GloboClima.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Auvo.GloboClima.Infra.Data.IoC;

namespace Auvo.GloboClima.API.IoC
{
    public static class RegisterServicesExtension
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterInfraServices(configuration);

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
            .AddSignInManager()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
            })
            .AddCookie()
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "https://globoclima.com",
                    ValidAudience = "https://globoclima.com/home",
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("u8f9Lk3v9QzX1aB7c2d9eF6gH3jK0mN5pR8sT1vW4yZ7="))
                };
            });

            //services
            services.AddScoped<ICountryService, CountryService>();
        }
    }
}
