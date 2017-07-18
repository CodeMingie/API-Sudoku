using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsTrack
{
    public class Summoner
    {
        public int id { get; set; }
        public string name { get; set; }
        public int profileIconId { get; set; }
        public int summonerLevel { get; set; }
        public long revisionDate { get; set; }
        public string revisionDateStr { get; set; }
    }

    public class Champion
    {
        public bool active	{ get; set; }
        public int attackRank	{ get; set; }
        public bool botEnabled { get; set; }
        public bool botMmEnabled	{ get; set; }
        public int defenseRank	{ get; set; }
        public int difficultyRank { get; set; }
        public bool freeToPlay { get; set; }
        public long id { get; set; }
        public int magicRank { get; set; }	
        public string name { get; set; }
        public bool rankedPlayEnabled { get; set; }	
    }
}
