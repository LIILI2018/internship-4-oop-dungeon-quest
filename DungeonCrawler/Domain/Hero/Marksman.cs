using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.Hero {
    public class Marksman : Hero {
        public double CritcalChance { get; set; }
        public double StunChance { get; set; }
        public Marksman() : base("Marksman", Utility.RandomInt(45, 55), Utility.RandomInt(45, 55), 10, 10) { }

        public void StunEnemy() {
            /*TODO*/
        }
    }
}
