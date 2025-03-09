using ReactJs.Core.Entities;
using ReactJs.Core.Interfaces.IMapper;
using ReactJs.Core.Interfaces.IRepositories;
using ReactJs.Core.Interfaces.IServices;
using ReactJs.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Services
{
    public class LoginService : BaseService<Employee, LoginResponse>, ILoginService
    {
        private readonly IBaseMapper<Employee, LoginResponse> _employeeModelMapper;
        private readonly IBaseMapper<LoginRequest, Employee> _employeeCreateMapper;
        private readonly IBaseMapper<LoginRequest, Employee> _employeeUpdateMapper;
        private readonly IEmployeeRepository _employeeRepository;

        public LoginService(
            IBaseMapper<Employee, LoginResponse> employeeModelMapper,
            IBaseMapper<LoginRequest, Employee> employeeCreateMapper,
            IBaseMapper<LoginRequest, Employee> employeeUpdateMapper,
            IEmployeeRepository employeeRepository)
            : base(employeeModelMapper, employeeRepository)
        {
            _employeeCreateMapper = employeeCreateMapper;
            _employeeUpdateMapper = employeeUpdateMapper;
            _employeeModelMapper = employeeModelMapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<LoginResponse> Login(LoginRequest model, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.Login(model, cancellationToken);
            var login = _employeeModelMapper.MapModel(employee);
            if (login!=null&&login.Username == model.Username && employee.Password == model.Password)
            {
                return login;
            }
            return null;
        }
         
    }
}
