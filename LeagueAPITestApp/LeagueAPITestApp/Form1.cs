using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatsTrack
{
    public partial class Form1 : Form
    {
        //const string key = "?api_key=4cc8a622-bb3d-434d-9a57-759f992d5b99";
        //string url = "https://prod.api.pvp.net/api/lol/na/v1.1/summoner/by-name/PandaMing";

        //string last_10_games = "https://prod.api.pvp.net/api/lol/na/v1.1/game/by-summoner/19942159/recent";

        public Form1()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            try
            {
                this.chart1.ChartAreas[0].AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
                WebManager web = new WebManager();
                web.SyncChampionPool();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
