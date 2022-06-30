using AutoMapper;
using LOL.Core.Entities.LOLEntities;
using LOL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOL.Domain.Mappers
{
    public class LOLMappingProfile : Profile
    {
        public LOLMappingProfile()
        {
            CreateMap<Chempion, ChempionModel>();
            CreateMap<ChempionModel, Chempion>();

            CreateMap<Items, ItemsModel>();
            CreateMap<ItemsModel, Items>();

            CreateMap<Role, RoleModel>();
            CreateMap<RoleModel, Role>();

            CreateMap<Team, TeamModel>();
            CreateMap<TeamModel, Team>();

            CreateMap<Tournament, TournamentModel>();
            CreateMap<TournamentModel, Tournament>();
        }
    }
}
