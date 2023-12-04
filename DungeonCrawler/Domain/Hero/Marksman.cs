using DungeonCrawler.Domain.Enemies;
using DungeonCrawler.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.Hero {
    public class Marksman : Hero {
        public double CritcalChance { get; set; } = 20;
        public double StunChance { get; set; } = 20;
        public Marksman() : base("Marksman", Utility.RandomInt(45, 55), Utility.RandomInt(45, 55), 10, 10) { }

        public override string AttackEnemy(Enemy enemy) {
            var x = Utility.RandomInt();
            if (x < CritcalChance) {
                enemy.HitPoints -= Damage * 2;
                return $"Kritično si napao {enemy.Name}a";
            }
            else if (x > 100 - StunChance) {
                enemy.HitPoints -= Damage;
                enemy.CanAttack = false;
                return $"Napao i stunao si {enemy.Name}a";
            }
            else { 
                enemy.HitPoints -= Damage;
                return $"Napao si {enemy.Name}a";
            }
        }
    }
}
