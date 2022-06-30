using LOL.Core.Entities.LOLEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOL.Core.Repositories.LOLRepositories
{
    public interface IChempionRepository : IGenericRepository<Chempion>
    {
        Task<List<Chempion>> GetAllChempions();
        Task<Chempion> GetChempionById(int id);
    }
}
