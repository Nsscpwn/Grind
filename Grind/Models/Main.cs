using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grind.Models
{
    public class Main
    {
        public Main()
        {
            this.UserModel = new UserModel();
            this.StatsModel = new StatsModel();
            this.SQL = new SqlCommands();
            this.UserLvlModel = new UserLvlModel();
            this.LvlStats = new LevelStatsModel();
            this.Fight = new Fight();
            this.CurrencyModel = new CurrencyModel();
            this.Rank = new Rank();
        }
        public UserModel UserModel { get; set; }
        public StatsModel StatsModel { get; set; }
        public SqlCommands SQL { get; set; }
        public UserLvlModel UserLvlModel { get; set; }
        public LevelStatsModel LvlStats { get; set; }
        public Fight Fight { get; set; }
        public CurrencyModel CurrencyModel { get; set; }
        public Rank Rank { get; set; }
    }
}