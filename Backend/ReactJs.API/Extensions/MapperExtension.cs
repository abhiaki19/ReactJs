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

            }).CreateMapper());

            // Register the IMapperService implementation with your dependency injection container
            services.AddSingleton<IBaseMapper<Employee, EmployeeResponce>, BaseMapper<Employee, EmployeeResponce>>();
            services.AddSingleton<IBaseMapper<EmployeeRequest, Employee>, BaseMapper<EmployeeRequest, Employee>>();

            #endregion

            return services;
        }
    }
}
