using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LOL.Core.Entities.LOLEntities
{
    public partial class Chempion
    {
        public string Version { get; set; }
        public string Id { get; set; }
        public int Key { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Blurb { get; set; }
        public string Tags { get; set; }
        public string Partype { get; set; }
        public double? Attack { get; set; }
        public double? Defense { get; set; }
        public double? Magic { get; set; }
        public double? Difficulty { get; set; }
        public double? Hp { get; set; }
        public double? Hpperlevel { get; set; }
        public double? Mp { get; set; }
        public double? Mpperlevel { get; set; }
        public double? Movespeed { get; set; }
        public double? Armor { get; set; }
        public double? Armorperlevel { get; set; }
        public double? Spellblock { get; set; }
        public double? Spellblockperlevel { get; set; }
        public double? Attackrange { get; set; }
        public double? Hpregen { get; set; }
        public double? Hpregenperlevel { get; set; }
        public double? Mpregen { get; set; }
        public double? Mpregenperlevel { get; set; }
        public double? Crit { get; set; }
        public double? Critperlevel { get; set; }
        public double? Attackdamage { get; set; }
        public double? Attackdamageperlevel { get; set; }
        public double? Attackspeedperlevel { get; set; }
        public double? Attackspeed { get; set; }
    }
}
