using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LOL.Core.Entities.LOLEntities
{
    public partial class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long? RegistrationTime { get; set; }
        public long? StartTime { get; set; }
        public bool? Cancalled { get; set; }
        public string NameKeySecondary { get; set; }
        public string NameKey { get; set; }
    }
}
