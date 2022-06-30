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
    public class TournamentService : ITournamentService
    {
        private readonly ILOLUnitOfWork lOLUnitOfWork;
        private readonly IMapper mapper;

        public TournamentService(ILOLUnitOfWork lOLUnitOfWork,
                                 IMapper mapper)
        {
            this.lOLUnitOfWork = lOLUnitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<TournamentModel>> GetAllAsync()
        {
            var list = await lOLUnitOfWork.TournamentRepository.GetBaseAllAsync();
            return mapper.Map<List<TournamentModel>>(list);
        }

        public async Task<TournamentModel> GetByIdAsync(int id)
        {
            var entity = await lOLUnitOfWork.TournamentRepository.GetBaseAsync(id);
            return mapper.Map<TournamentModel>(entity);
        }

        public async Task<int> CreateAsync(TournamentModel model)
        {
            var entity = mapper.Map<Tournament>(model);
            var tournament = await lOLUnitOfWork.TournamentRepository.GetBaseAsync(entity.Id);

            if (tournament != null) throw new EntityWasCreatedException(entity.Id);

            lOLUnitOfWork.TournamentRepository.Add(entity);
            await lOLUnitOfWork.SaveAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(TournamentModel model)
        {
            var entity = await lOLUnitOfWork.TournamentRepository.GetBaseAsync(model.Id);

            if (entity == null) throw new EntityNotFoundException(model.Id);

            mapper.Map(model, entity);
            lOLUnitOfWork.TournamentRepository.Update(entity);
            await lOLUnitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await lOLUnitOfWork.TournamentRepository.GetBaseAsync(id);

            if (entity == null) throw new EntityNotFoundException(id);

            lOLUnitOfWork.TournamentRepository.Remove(entity);
            await lOLUnitOfWork.SaveAsync();
        }
    }
}
