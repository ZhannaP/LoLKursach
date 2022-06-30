using AutoMapper;
using LOL.Core.Entities.LOLEntities;
using LOL.Core.Repositories;
using LOL.Core.Repositories.LOLRepositories;
using LOL.Core.Services;
using LOL.Core.UoWs;
using LOL.Domain.Contracts.Services;
using LOL.Domain.Models.ParsingModels;
using LOL.Domain.Services;
using LOL.Infrastructure.Repositories;
using LOL.Infrastructure.Repositories.LOLRepositories;
using LOL.Infrastructure.UoWs;
using LOL.Parser.Parse;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace LOL.Parser
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var container = new UnityContainer();

            RegisterTypes(container);

            ChampionsParserService list =
                new ChampionsParserService(container.Resolve<ILOLUnitOfWork>(), container.Resolve<IMapper>());

            try
            {
                //await list.ParseChampionsFromJson();
                await list.ParseTournamentFromJson();
                await list.ParseItemsFromJson();

                Console.WriteLine(list);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static void RegisterTypes(UnityContainer container)
        {
            container.RegisterType<ILOLUnitOfWork, LOLUnitOfWork>();
            container.RegisterType<IChempionService, ChempionService>();
            container.RegisterType<ITeamService, TeamService>();
            container.RegisterType<IDictionariesService, DictionariesService>();
            container.RegisterType<ITournamentService, TournamentService>();
            container.RegisterType<IItemService, ItemService>();
            container.RegisterType<IChampionsParserService, ChampionsParserService>();

            container.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            container.RegisterType<IChempionRepository, ChempionRepository>();
            container.RegisterType<ITeamRepository, TeamRepository>();

            var config = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Chempion, ParsedChempion>();
                mc.CreateMap<ParsedChempion, Chempion>()
                    .ForMember(dest => dest.Tags, opt => opt.MapFrom(x => String.Join(',', x.Tags)))
                    .ForMember(dest => dest.Attack, opt => opt.MapFrom(x => x.Info.Attack))
                    .ForMember(dest => dest.Defense, opt => opt.MapFrom(x => x.Info.Defense))
                    .ForMember(dest => dest.Magic, opt => opt.MapFrom(x => x.Info.Magic))
                    .ForMember(dest => dest.Difficulty, opt => opt.MapFrom(x => x.Info.Magic))
                    .ForMember(dest => dest.Hp, opt => opt.MapFrom(x => x.Stats.Hp))
                    .ForMember(dest => dest.Hpperlevel, opt => opt.MapFrom(x => x.Stats.Hpperlevel))
                    .ForMember(dest => dest.Mp, opt => opt.MapFrom(x => x.Stats.Mp))
                    .ForMember(dest => dest.Mpperlevel, opt => opt.MapFrom(x => x.Stats.Mpperlevel))
                    .ForMember(dest => dest.Armor, opt => opt.MapFrom(x => x.Stats.Armor))
                    .ForMember(dest => dest.Armorperlevel, opt => opt.MapFrom(x => x.Stats.Armorperlevel))
                    .ForMember(dest => dest.Spellblock, opt => opt.MapFrom(x => x.Stats.Spellblock))
                    .ForMember(dest => dest.Spellblockperlevel, opt => opt.MapFrom(x => x.Stats.Spellblockperlevel))
                    .ForMember(dest => dest.Attackrange, opt => opt.MapFrom(x => x.Stats.Attackrange))
                    .ForMember(dest => dest.Hpregen, opt => opt.MapFrom(x => x.Stats.Hpregen))
                    .ForMember(dest => dest.Hpregenperlevel, opt => opt.MapFrom(x => x.Stats.Hpregenperlevel))
                    .ForMember(dest => dest.Mpregen, opt => opt.MapFrom(x => x.Stats.Mpregen))
                    .ForMember(dest => dest.Mpregenperlevel, opt => opt.MapFrom(x => x.Stats.Mpregenperlevel))
                    .ForMember(dest => dest.Crit, opt => opt.MapFrom(x => x.Stats.Crit))
                    .ForMember(dest => dest.Critperlevel, opt => opt.MapFrom(x => x.Stats.Critperlevel))
                    .ForMember(dest => dest.Attackdamage, opt => opt.MapFrom(x => x.Stats.Attackdamage))
                    .ForMember(dest => dest.Attackdamageperlevel, opt => opt.MapFrom(x => x.Stats.Attackdamageperlevel))
                    .ForMember(dest => dest.Attackspeedperlevel, opt => opt.MapFrom(x => x.Stats.Attackspeedperlevel))
                    .ForMember(dest => dest.Attackspeed, opt => opt.MapFrom(x => x.Stats.Attackspeed))
                    .ForMember(dest => dest.Movespeed, opt => opt.MapFrom(x => x.Stats.Movespeed));

                mc.CreateMap<Tournament, ParsedTournament>();
                mc.CreateMap<ParsedTournament, Tournament>()
                    .ForMember(dest => dest.RegistrationTime, opt => opt.MapFrom(x => x.Schedule.RegistrationTime))
                    .ForMember(dest => dest.StartTime, opt => opt.MapFrom(x => x.Schedule.StartTime))
                    .ForMember(dest => dest.Cancalled, opt => opt.MapFrom(x => x.Schedule.Cancalled));

                mc.CreateMap<Items, ParsedItem>();
                mc.CreateMap<ParsedItem, Items>();

                mc.CreateMap<Items, Basic>();
                mc.CreateMap<Basic, Items>()
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.Type));
            });

            IMapper mapper = config.CreateMapper();
            container.RegisterInstance(mapper);
        }
    }
}
