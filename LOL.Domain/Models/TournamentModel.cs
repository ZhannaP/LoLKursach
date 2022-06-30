using System;
using System.Collections.Generic;
using System.Text;

namespace LOL.Domain.Models
{
    public class TournamentModel
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
