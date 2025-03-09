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
                cfg.CreateMap<Employee, EmployeeResponse>();
                cfg.CreateMap<EmployeeRequest, Employee>();

                cfg.CreateMap<Employee, LoginResponse>();
                cfg.CreateMap<LoginRequest, Employee>();

                cfg.CreateMap<ContactUs, ContactUsResponse>();
                cfg.CreateMap<ContactUsRequest, ContactUs>();

                cfg.CreateMap<Team, TeamResponse>();
                cfg.CreateMap<TeamRequest, Team>();


            }).CreateMapper());

            // Register the IMapperService implementation with your dependency injection container
            services.AddSingleton<IBaseMapper<Employee, EmployeeResponse>, BaseMapper<Employee, EmployeeResponse>>();
            services.AddSingleton<IBaseMapper<EmployeeRequest, Employee>, BaseMapper<EmployeeRequest, Employee>>();

            services.AddSingleton<IBaseMapper<Employee, LoginResponse>, BaseMapper<Employee, LoginResponse>>();
            services.AddSingleton<IBaseMapper<LoginRequest, Employee>, BaseMapper<LoginRequest, Employee>>();

            services.AddSingleton<IBaseMapper<ContactUs, ContactUsResponse>, BaseMapper<ContactUs, ContactUsResponse>>();
            services.AddSingleton<IBaseMapper<ContactUsRequest, ContactUs>, BaseMapper<ContactUsRequest, ContactUs>>();

            services.AddSingleton<IBaseMapper<Team, TeamResponse>, BaseMapper<Team, TeamResponse>>();
            services.AddSingleton<IBaseMapper<TeamRequest, Team>, BaseMapper<TeamRequest, Team>>();
            #endregion

            return services;
        }
    }
}
