using LOL.Core.Entities.LOLEntities;
using LOL.Core.Repositories;
using LOL.Core.Repositories.LOLRepositories;
using LOL.Core.UoWs;
using LOL.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOL.Infrastructure.UoWs
{
    public class LOLUnitOfWork : ILOLUnitOfWork
    {
        private readonly LOLContext context;

        public LOLUnitOfWork(LOLContext context,
                             IChempionRepository chempionRepository,
                             IGenericRepository<Items> itemRepository,
                             IGenericRepository<Role> roleRepository,
                             ITeamRepository teamRepository,
                             IGenericRepository<Tournament> tournamentRepository)
        {
            this.context = context;
            ChempionRepository = chempionRepository;
            ItemRepository = itemRepository;
            RoleRepository = roleRepository;
            TeamRepository = teamRepository;
            TournamentRepository = tournamentRepository;
        }

        public IChempionRepository ChempionRepository { get; private set; }

        public IGenericRepository<Items> ItemRepository { get; private set; }

        public IGenericRepository<Role> RoleRepository { get; private set; }

        public ITeamRepository TeamRepository { get; private set; }

        public IGenericRepository<Tournament> TournamentRepository { get; private set; }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
