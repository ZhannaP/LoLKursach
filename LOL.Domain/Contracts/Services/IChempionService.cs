using LOL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOL.Domain.Contracts.Services
{
    public interface IChempionService
    {
        Task<List<ChempionModel>> GetAllAsync();
        Task<ChempionModel> GetByIdAsync(int id);
        Task<int> CreateAsync(ChempionModel model);
        Task UpdateAsync(ChempionModel model);
        Task DeleteAsync(int id);
    }
}
