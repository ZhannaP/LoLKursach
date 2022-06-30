using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOL.Core.Services
{
    public interface IChampionsParserService
    {
        Task ParseChampionsFromJson();
        Task ParseTournamentFromJson();
        Task ParseItemsFromJson();
    }
}
