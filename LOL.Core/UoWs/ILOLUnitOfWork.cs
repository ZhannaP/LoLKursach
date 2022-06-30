using LOL.Core.Entities.LOLEntities;
using LOL.Core.Repositories;
using LOL.Core.Repositories.LOLRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOL.Core.UoWs
{
    public interface ILOLUnitOfWork : IUnitOfWork
    {
        IChempionRepository ChempionRepository { get; }
        IGenericRepository<Items> ItemRepository { get; }
        IGenericRepository<Role> RoleRepository { get; }
        ITeamRepository TeamRepository { get; }
        IGenericRepository<Tournament> TournamentRepository { get; }
    }
}
