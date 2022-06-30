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
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(LOLContext context) : base(context) { }
        public async Task<List<Team>> GetAllTeams()
        {
            return await context.Team
                .ToListAsync();
        }

        public async Task<Team> GetTeamById(int id)
        {
            return await context.Team
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
