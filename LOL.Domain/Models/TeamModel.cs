using System;
using System.Collections.Generic;
using System.Text;

namespace LOL.Domain.Models
{
    public class TeamModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Rating { get; set; }
        public int? TournamentId { get; set; }
    }
}
