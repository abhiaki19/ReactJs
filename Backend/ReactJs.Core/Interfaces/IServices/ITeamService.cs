using ReactJs.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Interfaces.IServices
{
    public interface ITeamService : IBaseService<TeamResponce>
    {
        Task<TeamResponce> Create(TeamRequest model, CancellationToken cancellationToken);
        Task Update(TeamRequest model, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
