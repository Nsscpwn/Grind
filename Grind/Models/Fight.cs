using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grind.Models
{
    public class Fight
    {
        public string textMessage { get; set; }
        public int PlayerDamage { get; set; }
        public int LevelDamage { get; set; }
        public int PlayerHealth { get; set; }
        public int LevelHealth { get; set; }
        public int Phases { get; set; }
        public string[] fightdet = new string[50];
    }
}