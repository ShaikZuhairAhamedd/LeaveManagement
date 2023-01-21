
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Modals.Identity;
using HR.LeaveManagement.Identity.Models;
using HR.LeaveManagement.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity
{
   public static  class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
         //   services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.Configure<JwtSettings>(options => {
                options.Key= configuration.GetSection("JwtSettings:Key").Value;
                options.Issuer = configuration.GetSection("JwtSettings:Issuer").Value;
                options.Audience = configuration.GetSection("JwtSettings:Audience").Value;
                options.DurationInMinutes= Convert.ToDouble(configuration.GetSection("JwtSettings:FromName").Value);
            });
            services.AddDbContext<LeaveManagementIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LeaveManagementIdentityConnectionString"),
                b => b.MigrationsAssembly(typeof(LeaveManagementIdentityDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>(config=> {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<LeaveManagementIdentityDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     //ValidateIssuer = false,
                     // ValidateAudience = false,
                     // ValidateLifetime = false,
                     //ValidateIssuerSigningKey = false,
                     ClockSkew = TimeSpan.FromMinutes(30),
                     ValidIssuer = configuration.GetSection("JwtSettings:Issuer").Value,
                     ValidAudience = configuration.GetSection("JwtSettings:Audience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JwtSettings:Key").Value))

                 };

             });


            return services;
        }


   }
}


/*
 *  Note Default Validation Paramters all below are True  * 
 *                   // ValidateIssuer 
                     // ValidateAudience 
                     // ValidateLifetime 
                     // ValidateIssuerSigningKey 

  so we have to specify the vaidationIssuer,validationAudience,issuerSignKey,HowManyDuration of  the token to be valid after the Creation...?
 */