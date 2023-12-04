using DungeonCrawler.Domain.Hero;

namespace DungeonCrawler.Domain.Enemies {
    public class Goblin : Enemy {
        public Goblin() : base("Goblin", Utility.RandomInt(15, 20), 100, Utility.RandomInt(30, 40)) { }
        public override void AttackPlayer(Hero.Hero hero, List<Enemy> enemies) {
            if (CanAttack) {
                hero.HitPoints -= Damage;
            }
            else {
                Console.WriteLine("Ne može napasti");
            }
        }
    }
}

