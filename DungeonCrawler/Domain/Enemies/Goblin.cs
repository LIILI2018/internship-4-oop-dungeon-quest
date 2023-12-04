using DungeonCrawler.Domain.Hero;

namespace DungeonCrawler.Domain.Enemies {
    public class Goblin : Enemy {
        public Goblin() : base("Goblin", Utility.RandomInt(30, 50), 100, Utility.RandomInt(30, 40)) { }
        public override string AttackPlayer(Hero.Hero hero, List<Enemy> enemies) {
            if (CanAttack) {
                hero.HitPoints -= Damage;
                return "Goblin te napao";
            }
            else {
                CanAttack = true;
                return "Goblin te ne može napasti";
            }
        }
    }
}

