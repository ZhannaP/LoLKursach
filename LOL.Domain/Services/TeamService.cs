using AutoMapper;
using LOL.Core.Entities.LOLEntities;
using LOL.Core.Exeptions;
using LOL.Core.UoWs;
using LOL.Domain.Contracts.Services;
using LOL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOL.Domain.Services
{
    public class TeamService : ITeamService
    {
        private readonly ILOLUnitOfWork lOLUnitOfWork;
        private readonly IMapper mapper;

        public TeamService(ILOLUnitOfWork lOLUnitOfWork,
                           IMapper mapper)
        {
            this.lOLUnitOfWork = lOLUnitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<TeamModel>> GetAllAsync()
        {
            var list = await lOLUnitOfWork.TeamRepository.GetAllTeams();
            return mapper.Map<List<TeamModel>>(list);
        }

        public async Task<TeamModel> GetByIdAsync(int id)
        {
            var entity = await lOLUnitOfWork.TeamRepository.GetTeamById(id);
            return mapper.Map<TeamModel>(entity);
        }

        public async Task<int> CreateAsync(TeamModel model)
        {
            var entity = mapper.Map<Team>(model);
            var team = await lOLUnitOfWork.TeamRepository.GetTeamById(entity.Id);

            if (team != null) throw new EntityWasCreatedException(entity.Id);

            lOLUnitOfWork.TeamRepository.Add(entity);
            await lOLUnitOfWork.SaveAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(TeamModel model)
        {
            var entity = await lOLUnitOfWork.TeamRepository.GetTeamById(model.Id);

            if (entity == null) throw new EntityNotFoundException(model.Id);

            mapper.Map(model, entity);
            lOLUnitOfWork.TeamRepository.Update(entity);
            await lOLUnitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await lOLUnitOfWork.TeamRepository.GetTeamById(id);

            if (entity == null) throw new EntityNotFoundException(id);

            lOLUnitOfWork.TeamRepository.Remove(entity);
            await lOLUnitOfWork.SaveAsync();
        }
    }
}
