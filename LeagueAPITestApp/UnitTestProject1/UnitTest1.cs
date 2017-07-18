using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using StatsTrack;

namespace StatsTrackUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        string myConnection;

        [TestInitialize]
        public void Initialize()
        {
            myConnection = "user id=sa; password=ming1988;server=.;Trusted_Connection=yes;database=StatsTrackUnitTest;connection timeout=30";
        }

        [TestCleanup]
        public void CleanUp()
        {
            string sql = "DELETE FROM " + Constants.Table.GameInfo;
            sql = sql + Environment.NewLine + "DELETE FROM " + Constants.Table.GameStats;
            SqlCommand cmd = new SqlCommand(sql);
            SqlConnection connection = new SqlConnection(myConnection);
            connection.Open();
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        [TestMethod]
        public void SaveLoadGameTest()
        {
            DatabaseManager manager = new DatabaseManager(myConnection);
            Game gameTestData = new Game();
            gameTestData.gameId = 2;
            gameTestData.invalid = false;
            gameTestData.gameMode = "Test Game Mode";
            gameTestData.gameType = "Test Game Type";
            gameTestData.subType = "Test Sub Type";
            gameTestData.mapId = 1;
            gameTestData.teamId = 1;
            gameTestData.championId = 1;
            gameTestData.spell1 = 1;
            gameTestData.spell2 = 1;
            gameTestData.level = 1;
            gameTestData.createDate = 1;
            gameTestData.createDateStr = 1;

            manager.Save(gameTestData);
            Game gameLoadData = manager.Load(gameTestData.gameId);
            AreGamesEqual(gameTestData, gameLoadData);
        }

        [TestMethod]
        public void SaveLoadStatsTest()
        {
            DatabaseManager manager = new DatabaseManager(myConnection);
            Statistic[] saveStats = new Statistic[2];
            Statistic stat1 = new Statistic();
            stat1.name = "Test1";
            stat1.value = 1;

            Statistic stat2 = new Statistic();
            stat2.name = "Test2";
            stat2.value = 2;

            saveStats[0] = stat1;
            saveStats[1] = stat2;

            manager.SaveStats(1, saveStats);
            Statistic[] loadStats = manager.LoadStats(1);

            foreach(Statistic stat in saveStats)
            {
                Statistic foundStat = Array.Find(loadStats, item => item.name == stat.name && item.value == stat.value);
                Assert.IsNotNull(foundStat);
            }

            

        }

        public void AreGamesEqual(Game game1, Game game2)
        {
            Assert.AreEqual(game1.gameId, game2.gameId);
            Assert.AreEqual(game1.invalid, game2.invalid);
            Assert.AreEqual(game1.gameMode, game2.gameMode);
            Assert.AreEqual(game1.gameType, game2.gameType);
            Assert.AreEqual(game1.subType, game2.subType);
            Assert.AreEqual(game1.mapId, game2.mapId);
            Assert.AreEqual(game1.teamId, game2.teamId);
            Assert.AreEqual(game1.championId, game2.championId);
            Assert.AreEqual(game1.spell1, game2.spell2);
            Assert.AreEqual(game1.spell2, game2.spell2);
            Assert.AreEqual(game1.level, game2.level);
            Assert.AreEqual(game1.createDate, game2.createDate);
            Assert.AreEqual(game1.createDateStr, game2.createDateStr);


            //Assert.AreEqual(game1.statistics.Length, game2.statistics.Length);

            //foreach (Statistic stat in game1.statistics)
            //{
            //    game2.statistics.GetValue(
            //}
            //TODO: Implement Stats Compare

        }
    }
}
