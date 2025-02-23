using ReactJs.Core.Interfaces.IRepositories;
using ReactJs.Core.Interfaces.IServices;
using ReactJs.Core.Services;
using ReactJs.Infrastructure.Repositories;

namespace ReactJs.API.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IEmployeeService, EmployeeService>();
            #endregion

            #region Repositories
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            #endregion

            return services;
        }
    }
}
