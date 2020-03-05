using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grind.Models
{
    public class StatsModel
    {
        public int Stats_ID { get; set; }
        public int Health { get; set; }
        public int Strenght { get; set; }
        public int Agility { get; set; }
        public int Dodge { get; set; }
        public int Critical_Chance { get; set; }
        public int Stats_User { get; set; }
        public int Damage { get; set; }
        public int Armour { get; set; }
    }
}