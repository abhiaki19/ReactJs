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
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
