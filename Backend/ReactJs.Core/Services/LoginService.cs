using ReactJs.Core.Entities;
using ReactJs.Core.Interfaces.IMapper;
using ReactJs.Core.Interfaces.IRepositories;
using ReactJs.Core.Interfaces.IServices;
using ReactJs.Core.Models;
using ReactJs.API.Authentication;
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
        private readonly IJwtProvider _jwtProvider;

        public LoginService(
            IBaseMapper<Employee, LoginResponse> employeeModelMapper,
            IBaseMapper<LoginRequest, Employee> employeeCreateMapper,
            IBaseMapper<LoginRequest, Employee> employeeUpdateMapper,
            IEmployeeRepository employeeRepository,
            IJwtProvider jwtProvider)
            : base(employeeModelMapper, employeeRepository)
        {
            _employeeCreateMapper = employeeCreateMapper;
            _employeeUpdateMapper = employeeUpdateMapper;
            _employeeModelMapper = employeeModelMapper;
            _employeeRepository = employeeRepository;
            _jwtProvider = jwtProvider;
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

        public async Task<LoginResponce> SignInAsync(LoginRequest model, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.Login(model, cancellationToken);
            var login = _employeeModelMapper.MapModel(employee);

            if (login is null)
            {
                throw new Exception($"Customer with id: '{model.Username}' was not found.");
            }

            if (login.Username == model.Username && employee.Password != model.Password)
            {
                throw new Exception($"Username or Password incorrect.");
            }

            login.Token = _jwtProvider.Generate(model.Username, model.Password);
            return login;
        }

    }
}
