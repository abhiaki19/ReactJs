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
    public class TeamService : BaseService<Team, TeamResponce>, ITeamService
    {
        private readonly IBaseMapper<Team, TeamResponce> _TeamModelMapper;
        private readonly IBaseMapper<TeamRequest, Team> _TeamCreateMapper;
        private readonly IBaseMapper<TeamRequest, Team> _TeamUpdateMapper;
        private readonly ITeamRepository _TeamRepository;

        public TeamService(
            IBaseMapper<Team, TeamResponce> TeamModelMapper,
            IBaseMapper<TeamRequest, Team> TeamCreateMapper,
            IBaseMapper<TeamRequest, Team> TeamUpdateMapper,
            ITeamRepository TeamRepository)
            : base(TeamModelMapper, TeamRepository)
        {
            _TeamCreateMapper = TeamCreateMapper;
            _TeamUpdateMapper = TeamUpdateMapper;
            _TeamModelMapper = TeamModelMapper;
            _TeamRepository = TeamRepository;
        }

        public async Task<TeamResponce> Create(TeamRequest model, CancellationToken cancellationToken)
        {
            //Mapping through AutoMapper
            var entity = _TeamCreateMapper.MapModel(model);
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = null;
            entity.UpdatedBy = null;

            return _TeamModelMapper.MapModel(await _TeamRepository.Create(entity, cancellationToken));
        }

        public async Task Update(TeamRequest model, CancellationToken cancellationToken)
        {
            var existingData = await _TeamRepository.GetById(model.Id, cancellationToken);

            //Mapping through AutoMapper
            model.CreatedDate = null;
            model.CreatedBy = null;
            _TeamUpdateMapper.MapModel(model, existingData);

            // Set additional properties or perform other logic as needed
            existingData.UpdatedDate = DateTime.Now;

            await _TeamRepository.Update(existingData, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _TeamRepository.GetById(id, cancellationToken);
            await _TeamRepository.Delete(entity, cancellationToken);
        }

    }
}
