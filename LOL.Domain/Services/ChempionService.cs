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
    public class ChempionService : IChempionService
    {
        private readonly ILOLUnitOfWork lOLUnitOfWork;
        private readonly IMapper mapper;

        public ChempionService(ILOLUnitOfWork lOLUnitOfWork,
                               IMapper mapper)
        {
            this.lOLUnitOfWork = lOLUnitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<ChempionModel>> GetAllAsync()
        {
            var list = await lOLUnitOfWork.ChempionRepository.GetAllChempions();
            return mapper.Map<List<ChempionModel>>(list);
        }

        public async Task<ChempionModel> GetByIdAsync(int id)
        {
            var entity = await lOLUnitOfWork.ChempionRepository.GetChempionById(id);
            return mapper.Map<ChempionModel>(entity);
        }

        public async Task<int> CreateAsync(ChempionModel model)
        {
            var entity = mapper.Map<Chempion>(model);
            var chempion = await lOLUnitOfWork.ChempionRepository.GetChempionById(entity.Key);

            if (chempion != null) throw new EntityWasCreatedException(entity.Key);

            lOLUnitOfWork.ChempionRepository.Add(entity);
            await lOLUnitOfWork.SaveAsync();
            return entity.Key;
        }

        public async Task UpdateAsync(ChempionModel model)
        {
            var entity = await lOLUnitOfWork.ChempionRepository.GetChempionById(model.Key);

            if (entity == null) throw new EntityNotFoundException(model.Key);

            mapper.Map(model, entity);
            lOLUnitOfWork.ChempionRepository.Update(entity);
            await lOLUnitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await lOLUnitOfWork.ChempionRepository.GetChempionById(id);

            if (entity == null) throw new EntityNotFoundException(id);

            lOLUnitOfWork.ChempionRepository.Remove(entity);
            await lOLUnitOfWork.SaveAsync();
        }
    }
}
