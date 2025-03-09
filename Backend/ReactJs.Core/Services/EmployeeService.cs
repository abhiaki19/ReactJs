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
    public class EmployeeService : BaseService<Employee, EmployeeResponse>, IEmployeeService
    {
        private readonly IBaseMapper<Employee, EmployeeResponse> _employeeModelMapper;
        private readonly IBaseMapper<EmployeeRequest, Employee> _employeeCreateMapper;
        private readonly IBaseMapper<EmployeeRequest, Employee> _employeeUpdateMapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(
            IBaseMapper<Employee, EmployeeResponse> employeeModelMapper,
            IBaseMapper<EmployeeRequest, Employee> employeeCreateMapper,
            IBaseMapper<EmployeeRequest, Employee> employeeUpdateMapper,
            IEmployeeRepository employeeRepository)
            : base(employeeModelMapper, employeeRepository)
        {
            _employeeCreateMapper = employeeCreateMapper;
            _employeeUpdateMapper = employeeUpdateMapper;
            _employeeModelMapper = employeeModelMapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeResponse> Create(EmployeeRequest model, CancellationToken cancellationToken)
        {
            //Mapping through AutoMapper
            var entity = _employeeCreateMapper.MapModel(model);
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = null;
            entity.UpdatedBy = null;

            return _employeeModelMapper.MapModel(await _employeeRepository.Create(entity, cancellationToken));
        }

        public async Task Update(EmployeeRequest model, CancellationToken cancellationToken)
        {
            var existingData = await _employeeRepository.GetById(model.Id, cancellationToken);

            //Mapping through AutoMapper
            model.CreatedDate = null;
            model.CreatedBy = null;
            _employeeUpdateMapper.MapModel(model, existingData);

            // Set additional properties or perform other logic as needed
            existingData.UpdatedDate = DateTime.Now;

            await _employeeRepository.Update(existingData, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _employeeRepository.GetById(id, cancellationToken);
            await _employeeRepository.Delete(entity, cancellationToken);
        }

    }
}
