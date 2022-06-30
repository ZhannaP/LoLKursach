using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LOL.Core.Entities.LOLEntities
{
    public partial class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Rating { get; set; }
        public int? TournamentId { get; set; }
    }
}
