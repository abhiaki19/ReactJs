using Microsoft.EntityFrameworkCore;
using ReactJs.Core.Entities;
using ReactJs.Core.Interfaces.IRepositories;
using ReactJs.Core.Models;
using ReactJs.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<Employee> Login(LoginRequest model, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Employees.Where(x => x.Username.Contains(model.Username)).FirstOrDefaultAsync();
        }
    }
}
