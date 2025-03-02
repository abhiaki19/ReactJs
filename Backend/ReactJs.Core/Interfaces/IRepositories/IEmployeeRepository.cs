using ReactJs.Core.Entities;
using ReactJs.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Interfaces.IRepositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
         Task<Employee> Login(LoginRequest model, CancellationToken cancellationToken = default);
    }
}
