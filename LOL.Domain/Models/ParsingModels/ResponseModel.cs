using System;
using System.Collections.Generic;
using System.Text;

namespace LOL.Domain.Models.ParsingModels
{
    public class ResponseModel
    {
        public string Type { get; set; }
        public string Version { get; set; }
        public Dictionary<string, ParsedChempion> Data { get; set; }
    }

    public class ParsedChempion
    {
        public string Version { get; set; }
        public string Id { get; set; }
        public int Key { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Blurb { get; set; }
        public Info Info { get; set; }
        public string[] Tags { get; set; }
        public string Partype { get; set; }
        public Stats Stats { get; set; }
    }

    public class Info
    {
        public float Attack { get; set; }
        public float Defense { get; set; }
        public float Magic { get; set; }
        public float Difficulty { get; set; }
    }

    public class Stats
    {
        public float Hp { get; set; }
        public float Hpperlevel { get; set; }
        public float Mp { get; set; }
        public float Mpperlevel { get; set; }
        public float Movespeed { get; set; }
        public float Armor { get; set; }
        public float Armorperlevel { get; set; }
        public float Spellblock { get; set; }
        public float Spellblockperlevel { get; set; }
        public float Attackrange { get; set; }
        public float Hpregen { get; set; }
        public float Hpregenperlevel { get; set; }
        public float Mpregen { get; set; }
        public float Mpregenperlevel { get; set; }
        public float Crit { get; set; }
        public float Critperlevel { get; set; }
        public float Attackdamage { get; set; }
        public float Attackdamageperlevel { get; set; }
        public float Attackspeedperlevel { get; set; }
        public float Attackspeed { get; set; }
    }


    public class ParsedTournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameKey { get; set; }
        public string NameKeySecondary { get; set; }
        public Schedule Schedule { get; set; }

    }

    public class Schedule
    {
        public Dictionary<int, Objects> Objects { get; set; }
    }


    public class Objects
    {
        public long? RegistrationTime { get; set; }
        public long? StartTime { get; set; }
        public bool? Cancalled { get; set; }

    }

    public class ParsedItem
    {
        public string Type { get; set; }
        public string Version { get; set; }
        public Dictionary<string, Basic> Basic { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
    }

    public class Basic
    {
        //public bool IsRune { get; set; }
        public string Type { get; set; }
    }
}
