using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StatsTrack
{
    public class DatabaseManager
    {
        string connString;

        public DatabaseManager(string connString)
        {
            this.connString = connString;
        }

        #region ---- Game ----

        public void Save(RecentGames games)
        {
            foreach (Game game in games.games)
                Save(game);
        }

        public void Save(Game game)
        {
            //CreateStatColumns(game);
            string sql = string.Format(@"IF NOT EXISTS(SELECT * FROM GameStats WHERE GameID = {1})
                                        INSERT INTO {0} (GameID, Invalid, GameMode, GameType, SubType, MapID, TeamID, ChampionID, Spell1, Spell2, CreateDate, CreateDateStr, Level) 
                                        VALUES ({1}, {2}, '{3}', '{4}', '{5}', {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13})", Constants.Table.GameInfo,
                    game.gameId, game.invalid ? 1 : 0, game.gameMode, game.gameType, game.subType, game.mapId, game.teamId, game.championId, game.spell1, game.spell2, game.level, game.createDate, game.createDateStr, game.level);
            this.RunSQL(sql);
            SaveStats(game.gameId, game.statistics);
        }

        public Game Load(int gameID)
        {
            Game game = new Game();

            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            string sql = string.Format("SELECT TOP 1 * FROM {0} WHERE GameID = {1}", Constants.Table.GameInfo, gameID.ToString());
            cmd.CommandText = sql;
            SqlDataReader dtr = cmd.ExecuteReader();

            try
            {
                while (dtr.Read())
                {
                    game.gameId = (int)dtr["GameID"];
                    game.invalid = (bool)dtr["Invalid"];
                    game.gameMode = (string)dtr["GameMode"];
                    game.gameType = (string)dtr["GameType"];
                    game.subType = (string)dtr["SubType"];
                    game.mapId = (int)dtr["MapID"];
                    game.teamId = (int)dtr["TeamID"];
                    game.championId = (int)dtr["ChampionID"];
                    game.spell1 = (int)dtr["Spell1"];
                    game.spell2 = (int)dtr["Spell2"];
                    game.createDate = (long)dtr["CreateDate"];
                    game.createDateStr = (long)dtr["CreateDateStr"];
                    game.level = (int)dtr["Level"];

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                dtr.Close();
                sqlConnection.Close();
            }

            return game;
        }

        #endregion
        #region ---- Stats ----

        public void SaveStats(int gameID, Statistic[] stats)
        {
            if (stats == null)
                return;

            CreateStatColumns(stats);

            string[] columnNames = new string[stats.Length];
            int[] values = new int[stats.Length];

            for (int i = 0; i < stats.Length; i++)
            {
                Statistic stat = stats[i];
                columnNames[i] = stat.name;
                values[i] = stat.value;
            }

            string insertClause = string.Format(@"IF NOT EXISTS(SELECT * FROM {0} WHERE GameID = {1}) INSERT INTO {0} (GameID, " + String.Join(",", columnNames) + ")", Constants.Table.GameStats, gameID.ToString());
            string valueClause = "VALUES(" + gameID.ToString() + "," + String.Join(",", values) + ")";
            string sql = insertClause + Environment.NewLine + valueClause;
            this.RunSQL(sql);
        }

        public Statistic[] LoadStats(int gameID)
        {
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            string sql = string.Format("SELECT TOP 1 * FROM {0} WHERE GameID = {1}", Constants.Table.GameStats, gameID.ToString());
            cmd.CommandText = sql;
            SqlDataReader dtr = cmd.ExecuteReader();

            Statistic[] stats = new Statistic[dtr.FieldCount];

            try
            {
                while (dtr.Read())
                {
                    for (int i = 0; i < dtr.FieldCount; i++)
                    {
                        Statistic stat = new Statistic();
                        stat.name = dtr.GetName(i);
                        object value = dtr.GetValue(i);
                        if (value == DBNull.Value)
                            stat.value = 0;
                        else
                            stat.value = (int) value;
                        stats[i] = stat;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                dtr.Close();
            }

            return stats;

        }

        public void CreateStatColumns(Statistic[] statistics)
        {
            if (statistics == null)
                return;

            foreach (Statistic stat in statistics)
            {
                string sql = string.Format(@"IF NOT EXISTS(SELECT * FROM sys.columns WHERE name = '{1}' AND object_id = OBJECT_ID('{0}'))
                                             ALTER TABLE {0} ADD {1} int NULL", Constants.Table.GameStats, stat.name);

                this.RunSQL(sql);
            }
        }

        #endregion
        #region ---- Champion ----

        public void Save(List<Champion> champions)
        {
            foreach (Champion champ in champions)
                this.Save(champ);
        }

        public void Save(Champion champion)
        {
            string sql = string.Format(@"IF NOT EXISTS(SELECT * FROM {0} WHERE id = '{1}')
                                        INSERT INTO {0} (Id, Name) VALUES  ({1}, {2})", Constants.Table.Champion, champion.id, champion.name);
            this.RunSQL(sql);
        }

        #endregion
        #region ---- RunSQL ----

        public void RunSQL(string sql)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();
            }
        }

        #endregion
    }
}
