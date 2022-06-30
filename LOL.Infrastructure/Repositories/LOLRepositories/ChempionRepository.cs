using LOL.Core.Entities.LOLEntities;
using LOL.Core.Repositories.LOLRepositories;
using LOL.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOL.Infrastructure.Repositories.LOLRepositories
{
    public class ChempionRepository : GenericRepository<Chempion>, IChempionRepository
    {
        public ChempionRepository(LOLContext context) : base(context) { }

        public async Task<List<Chempion>> GetAllChempions()
        {
            return await context.Chempion
                //.Include(x => x.Role)
                .ToListAsync();
        }

        public async Task<Chempion> GetChempionById(int id)
        {
            return await context.Chempion
                //.Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Key == id);
        }
    }
}
