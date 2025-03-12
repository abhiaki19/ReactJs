using Microsoft.OpenApi.Models;
using ReactJs.Core.Interfaces.IRepositories;
using ReactJs.Core.Interfaces.IServices;
using ReactJs.Core.Services;
using ReactJs.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ReactJs.API.Authentication;

namespace ReactJs.API.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IContactUsService, ContactUsService>();
            #endregion

            #region Repositories
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IContactUsRepository, ContactUsRepository>();

            #endregion 
            return services;
        }

       
    }
}
