using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grind.Models
{
    public class LevelStatsModel
    {
        public int level_Health { get; set; }
        public int level_Armour { get; set; }
        public int level_Damage { get; set; }
        public int level_Strenght { get; set; }
        public int level_Agility { get; set; }
        public int level_Dodge { get; set; }
        public int level_Critical { get; set; }
        public int level_Boss { get; set; }
        public int level_Gold_Min { get; set; }
        public int level_gold_Max { get; set; }
        public int stats_Point  { get; set; }
        public int skill_Point { get; set; }

    }
}