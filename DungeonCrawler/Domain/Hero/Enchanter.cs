using DungeonCrawler.Domain.Enemies;
using DungeonCrawler.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.Hero {
    public class Enchanter : Hero {
        public double Mana { get; set; }
        public double MaxMana { get; set; } = 100;
        private bool CanReturnFromDead { get; set; } = true;
        public Enchanter() : base("Enchanter", Utility.RandomInt(50, 60), Utility.RandomInt(40, 50), 10, 10) { }

        public void ReturnFromDead() {
            /*TODO*/
        }

        public override void Heal() {
            Mana = MaxMana;
            base.Heal();
        }
        public override void LevelUp() {
            base.LevelUp();
            if (ExperiencePoints > 100) {
                MaxMana += 10;
            }
        }

        public override void AttackEnemy(Enemy enemy) {
            if  (Mana > 0) { 
                var x = Inputs.OptionInput([$"1 - Napadni normalnim napadom ({Damage} dmg)", $"2 - Obnovi život (+{MaxHPIncrease * 0.4} HP, -{MaxMana * 0.5} Mana)"]);    
                if (x == 1) {
                    Mana -= 10;
                    enemy.HitPoints -= Damage;
                }
                else {
                    Mana -= MaxMana * 0.5;
                    HitPoints += MaxHPIncrease * 0.4;
                }
            }
            else {
                Inputs.Wait("Ne možeš napasti ovaj krug jer nemaš mane");
                Mana += MaxMana * 0.5;
            }
        }
        public override bool Death() {
            HitPoints = MaxHitPoints;
            Mana = MaxMana;
            var x = CanReturnFromDead;
            CanReturnFromDead = false;
            Console.WriteLine("Vračaš se iz mrtvih");
            return !x;
        }
    }
}
