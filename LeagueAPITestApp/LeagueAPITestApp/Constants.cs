using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsTrack
{
    public class Constants
    {
        public class Table
        {
            public static string GameInfo = "GameInfo";
            public static string GameStats = "GameStats";
            public static string Champion = "Champion";
        }

        public class Misc
        {
            public static string key = "?api_key=4cc8a622-bb3d-434d-9a57-759f992d5b99";
            public static string url = "https://prod.api.pvp.net/api/lol/na/v1.1/summoner/by-name/PandaMing";
            public static string last_10_games = "https://prod.api.pvp.net/api/lol/na/v1.1/game/by-summoner/19942159/recent";
            public static string champion = "https://prod.api.pvp.net/api/lol/na/v1.1/champion";
            public static int maxRequestPerTenSec = 3;
        }
    }
}
