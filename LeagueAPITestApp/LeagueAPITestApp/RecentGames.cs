using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsTrack
{
    public class RecentGames
    {
        public int summonerId { get; set; }
        public Game[] games { get; set; }
    }

    public class Game
    {
        public int gameId { get; set; }
        public bool invalid { get; set; }
        public string gameMode { get; set; }
        public string gameType { get; set; }
        public string subType { get; set; }
        public int mapId { get; set; }
        public int teamId { get; set; }
        public int championId { get; set; }
        public int spell1 { get; set; }
        public int spell2 { get; set; }
        public int level { get; set; }
        public long createDate { get; set; }
        public long createDateStr { get; set; }
        public Fellowplayer[] fellowPlayers { get; set; }
        public Statistic[] statistics { get; set; }
    }

    public class Fellowplayer
    {
        public int summonerId { get; set; }
        public int teamId { get; set; }
        public int championId { get; set; }
    }

    public class Statistic
    {
        public int id { get; set; }
        public string name { get; set; }
        public int value { get; set; }
    }

}
