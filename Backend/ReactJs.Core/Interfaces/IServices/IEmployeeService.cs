using ReactJs.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Interfaces.IServices
{
    public interface IEmployeeService : IBaseService<EmployeeResponse>
    {
        Task<EmployeeResponse> Create(EmployeeRequest model, CancellationToken cancellationToken);
        Task Update(EmployeeRequest model, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
