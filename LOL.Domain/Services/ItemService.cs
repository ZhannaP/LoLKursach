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
    public class ItemService : IItemService
    {
        private readonly ILOLUnitOfWork lOLUnitOfWork;
        private readonly IMapper mapper;

        public ItemService(ILOLUnitOfWork lOLUnitOfWork,
                           IMapper mapper)
        {
            this.lOLUnitOfWork = lOLUnitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<ItemsModel>> GetAllAsync()
        {
            var list = await lOLUnitOfWork.ItemRepository.GetBaseAllAsync();
            return mapper.Map<List<ItemsModel>>(list);
        }

        public async Task<ItemsModel> GetByIdAsync(int id)
        {
            var entity = await lOLUnitOfWork.ItemRepository.GetBaseAsync(id);
            return mapper.Map<ItemsModel>(entity);
        }

        public async Task<int> CreateAsync(ItemsModel model)
        {
            var entity = mapper.Map<Items>(model);
            var item = await lOLUnitOfWork.ItemRepository.GetBaseAsync(entity.Id);

            if (item != null) throw new EntityWasCreatedException(entity.Id);

            lOLUnitOfWork.ItemRepository.Add(entity);
            await lOLUnitOfWork.SaveAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(ItemsModel model)
        {
            var entity = await lOLUnitOfWork.ItemRepository.GetBaseAsync(model.Id);

            if (entity == null) throw new EntityNotFoundException(model.Id);

            mapper.Map(model, entity);
            lOLUnitOfWork.ItemRepository.Update(entity);
            await lOLUnitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await lOLUnitOfWork.ItemRepository.GetBaseAsync(id);

            if (entity == null) throw new EntityNotFoundException(id);

            lOLUnitOfWork.ItemRepository.Remove(entity);
            await lOLUnitOfWork.SaveAsync();
        }
    }
}
