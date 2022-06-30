using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LOL.Core.Entities.LOLEntities
{
    public partial class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsRune { get; set; }
        public string Type { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
    }
}
