using AutoMapper;
using LOL.Core.Entities.LOLEntities;
using LOL.Core.Services;
using LOL.Core.UoWs;
using LOL.Domain.Models.ParsingModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LOL.Parser.Parse
{
    public class ChampionsParserService : IChampionsParserService
    {
        private readonly ILOLUnitOfWork lolUnitOfWork;
        private readonly IMapper mapper;

        public ChampionsParserService(ILOLUnitOfWork lolUnitOfWork, IMapper mapper)
        {
            this.lolUnitOfWork = lolUnitOfWork;
            this.mapper = mapper;
        }

        public async Task ParseChampionsFromJson()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client
                .GetAsync("http://ddragon.leagueoflegends.com/cdn/12.6.1/data/en_US/champion.json");
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(responseBody);
            ResponseModel responseModel = JsonConvert.DeserializeObject<ResponseModel>(result.ToString());
            List<ParsedChempion> parsedChempions = new List<ParsedChempion>();
            List<Chempion> chempions = new List<Chempion>();

            foreach (var chempion in responseModel.Data.Values) parsedChempions.Add(chempion);

            mapper.Map(parsedChempions, chempions);

            lolUnitOfWork.ChempionRepository.AddRange(chempions);
            await lolUnitOfWork.SaveAsync();
        }

        public async Task ParseTournamentFromJson()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client
                .GetAsync("https://br1.api.riotgames.com/lol/clash/v1/tournaments?api_key=RGAPI-ad7ea70a-dc3c-4755-a4fb-59c9f54f6b95");
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(responseBody);
            List<ParsedTournament> responseModel = 
                JsonConvert.DeserializeObject<List<ParsedTournament>>(result.ToString());
            List<ParsedTournament> parsedTournaments = new List<ParsedTournament>();
            List<Tournament> tournaments = new List<Tournament>();

            foreach (var tournament in responseModel) parsedTournaments.Add(tournament);

            mapper.Map(parsedTournaments, tournaments);

            lolUnitOfWork.TournamentRepository.AddRange(tournaments);
            await lolUnitOfWork.SaveAsync();
        }

        public async Task ParseItemsFromJson()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client
                .GetAsync("http://ddragon.leagueoflegends.com/cdn/12.6.1/data/en_US/champion.json");
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(responseBody);
            ParsedItem responseModel = JsonConvert.DeserializeObject<ParsedItem>(result.ToString());
            List<Basic> parsedItems = new List<Basic>();
            List<Items> items = new List<Items>();

            foreach (var chempion in responseModel.Basic.Values) parsedItems.Add(chempion);

            mapper.Map(parsedItems, items);

            lolUnitOfWork.ItemRepository.AddRange(items);
            await lolUnitOfWork.SaveAsync();
        }
    }
}
