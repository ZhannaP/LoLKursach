using LOL.Core.Entities.LOLEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOL.Core.Repositories.LOLRepositories
{
    public interface ITeamRepository : IGenericRepository<Team>
    {
        Task<List<Team>> GetAllTeams();
        Task<Team> GetTeamById(int id);
    }
}
