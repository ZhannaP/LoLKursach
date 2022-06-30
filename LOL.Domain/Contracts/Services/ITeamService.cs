using LOL.Core.Entities.LOLEntities;
using LOL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOL.Domain.Contracts.Services
{
    public interface ITeamService
    {
        Task<List<TeamModel>> GetAllAsync();
        Task<TeamModel> GetByIdAsync(int id);
        Task<int> CreateAsync(TeamModel model);
        Task UpdateAsync(TeamModel model);
        Task DeleteAsync(int id);
    }
}
