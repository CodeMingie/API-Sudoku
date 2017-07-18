using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StatsTrack
{
    public class WebManager
    {
        int requestCount;
        static string sqlConnection = "user id=sa; password=ming1988;server=.;Trusted_Connection=yes;database=StatsTrackTest;connection timeout=30";
        DatabaseManager manager = new DatabaseManager(sqlConnection);

        public WebManager()
        {
            requestCount = 0;
        }

        public string RequestRiotAPI(string requestURL)
        {
            if (requestCount >= Constants.Misc.maxRequestPerTenSec)
                Thread.Sleep(1000);

            requestCount++;

            using (var webClient = new System.Net.WebClient())
            {
                return webClient.DownloadString(requestURL + Constants.Misc.key);
            }
        }

        public void SyncLastTenGames()
        {
            var json = RequestRiotAPI(Constants.Misc.last_10_games);
            RecentGames games = JsonConvert.DeserializeObject<RecentGames>(json);
            manager.Save(games);
            requestCount++;
        }

        public void SyncChampionPool()
        {
            var json = RequestRiotAPI(Constants.Misc.champion);
            List<Champion> champions = JsonConvert.DeserializeObject<List<Champion>>(json);
            manager.Save(champions);

        }
    }
}
