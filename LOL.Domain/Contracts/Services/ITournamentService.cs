using LOL.Core.Entities.LOLEntities;
using LOL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOL.Domain.Contracts.Services
{
    public interface ITournamentService
    {
        Task<List<TournamentModel>> GetAllAsync();
        Task<TournamentModel> GetByIdAsync(int id);
        Task<int> CreateAsync(TournamentModel model);
        Task UpdateAsync(TournamentModel model);
        Task DeleteAsync(int id);
    }
}
