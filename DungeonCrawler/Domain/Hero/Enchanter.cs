using DungeonCrawler.Domain.Enemies;
using DungeonCrawler.Presentation;

namespace DungeonCrawler.Domain.Hero {
    public class Enchanter : Hero {
        public double Mana { get; set; } = 100;
        public double MaxMana { get; set; } = 100;
        private bool secondLife { get; set; } = true;
        public Enchanter() : base("Enchanter", Utility.RandomInt(50, 60), Utility.RandomInt(40, 50), 20, 15) { }

        protected override void Heal() {
            Mana = MaxMana;
            base.Heal();
        }

        protected override void LevelUp() {
            base.LevelUp();
            if (ExperiencePoints > 100) {
                MaxMana += 10;
            }
        }

        public override string AttackEnemy(Enemy enemy) {
            if  (Mana > 0) { 
                var x = Inputs.OptionInput([$"1 - Napadni normalnim napadom ({Damage} dmg)", $"2 - Obnovi život (+{_maxHPIncrease * 0.4} HP, -{MaxMana * 0.5} Mana)"]);    
                if (x == 1) {
                    Mana -= 10;
                    enemy.HitPoints -= Damage;
                    return $"Napao si {enemy.Name}a";
                }
                else {
                    Mana -= MaxMana * 0.5;
                    HitPoints += _maxHPIncrease * 0.4;
                    return $"Healao si se";
                }
            }
            else {
                Mana += MaxMana * 0.5;
                return $"Ne možeš napasti ovaj krug jer nemaš mane";
            }
        }

        public override bool SecondLife() {
            if (secondLife) { 
                HitPoints = MaxHitPoints;
                Mana = MaxMana;
                secondLife = false;
                Inputs.Wait("Poginio si\n\nOvo ti je 2. život");
                return false;
            }
            return true;
        }
    }
}
