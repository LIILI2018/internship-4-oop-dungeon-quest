using DungeonCrawler.Domain.Enemies;
using DungeonCrawler.Presentation;

namespace DungeonCrawler.Domain.Hero {
    public class Gladiator : Hero {
        public Gladiator() : base("Gladiator", Utility.RandomInt(180, 200), Utility.RandomInt(20, 25), 30, 10) { }
        public override string AttackEnemy(Enemy enemy) {
            var x = Inputs.OptionInput([$"1 - Napadni normalnim napadom ({Damage} dmg)", $"2 - Napadni bijesnim napadom ({Damage * 2} dmg,-{MaxHitPoints * 0.1} HP)"]);
            if (x == 1) {
                enemy.HitPoints -= Damage;
                return $"Napao si {enemy.Name}";
            }
            else {
                HitPoints -= 0.1 * MaxHitPoints;
                enemy.HitPoints -= Damage * 2;
                return $"Bijesno si napao {enemy.Name}";
            }
        }
    }
}
