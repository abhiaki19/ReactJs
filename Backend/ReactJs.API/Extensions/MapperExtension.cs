using AutoMapper;
using ReactJs.Core.Entities;
using ReactJs.Core.Interfaces.IMapper;
using ReactJs.Core.Mapper;
using ReactJs.Core.Models;
using System.Data;

namespace ReactJs.API.Extensions
{
    public static class MapperExtension
    {
        public static IServiceCollection RegisterMapperService(this IServiceCollection services)
        {

            #region Mapper

            services.AddSingleton<IMapper>(sp => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeResponce>();
                cfg.CreateMap<EmployeeRequest, Employee>();

                cfg.CreateMap<Employee, LoginResponce>();
                cfg.CreateMap<LoginRequest, Employee>();

                cfg.CreateMap<Team, TeamResponce>();
                cfg.CreateMap<TeamRequest, Team>();

            }).CreateMapper());

            // Register the IMapperService implementation with your dependency injection container
            services.AddSingleton<IBaseMapper<Employee, EmployeeResponce>, BaseMapper<Employee, EmployeeResponce>>();
            services.AddSingleton<IBaseMapper<EmployeeRequest, Employee>, BaseMapper<EmployeeRequest, Employee>>();

            services.AddSingleton<IBaseMapper<Employee, LoginResponce>, BaseMapper<Employee, LoginResponce>>();
            services.AddSingleton<IBaseMapper<LoginRequest, Employee>, BaseMapper<LoginRequest, Employee>>();

            services.AddTransient<IBaseMapper<Team, TeamResponce>, BaseMapper<Team, TeamResponce>>();
            services.AddTransient<IBaseMapper<TeamRequest, Team>, BaseMapper<TeamRequest, Team>>();
            #endregion

            return services;
        }
    }
}
