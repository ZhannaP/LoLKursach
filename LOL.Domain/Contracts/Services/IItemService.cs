using LOL.Core.Entities.LOLEntities;
using LOL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOL.Domain.Contracts.Services
{
    public interface IItemService
    {
        Task<List<ItemsModel>> GetAllAsync();
        Task<ItemsModel> GetByIdAsync(int id);
        Task<int> CreateAsync(ItemsModel model);
        Task UpdateAsync(ItemsModel model);
        Task DeleteAsync(int id);
    }
}
