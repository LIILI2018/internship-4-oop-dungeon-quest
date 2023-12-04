using DungeonCrawler.Domain.Enemies;
using DungeonCrawler.Presentation;

namespace DungeonCrawler.Domain.Hero {
    public class Enchanter : Hero {
        public double Mana { get; set; } = 100;
        public double MaxMana { get; set; } = 100;
        private bool CanReturnFromDead { get; set; } = true;
        public Enchanter() : base("Enchanter", Utility.RandomInt(50, 60), Utility.RandomInt(40, 50), 20, 15) { }

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
        public override string AttackEnemy(Enemy enemy) {
            if  (Mana > 0) { 
                var x = Inputs.OptionInput([$"1 - Napadni normalnim napadom ({Damage} dmg)", $"2 - Obnovi život (+{MaxHPIncrease * 0.4} HP, -{MaxMana * 0.5} Mana)"]);    
                if (x == 1) {
                    Mana -= 10;
                    enemy.HitPoints -= Damage;
                    return $"Napao si {enemy.Name}a";

                }
                else {
                    Mana -= MaxMana * 0.5;
                    HitPoints += MaxHPIncrease * 0.4;
                    return $"Healao si se";

                }
            }
            else {
                Mana += MaxMana * 0.5;
                return $"Ne možeš napasti ovaj krug jer nemaš mane";
            }
        }
        public override bool SecondLife() {
            if (CanReturnFromDead) { 
                HitPoints = MaxHitPoints;
                Mana = MaxMana;
                var x = CanReturnFromDead;
                CanReturnFromDead = false;
                Inputs.Wait("Poginio si\n\nOvo ti je 2. život");
                return !x;
            }
            return false;
        }
    }
}
