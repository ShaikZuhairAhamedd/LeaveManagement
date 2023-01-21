
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Modals;
using HR.LeaveManagement.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(options=> {
                options.ApiKey = configuration.GetSection("EmailSettings:ApiKey").Value;
                options.FromAddress = configuration.GetSection("EmailSettings:FromAddress").Value;
                options.FromName = configuration.GetSection("EmailSettings:FromName").Value;
            });
            services.AddTransient<IEmailSender, EmailSender>();


            return services;

        }
    }
}
