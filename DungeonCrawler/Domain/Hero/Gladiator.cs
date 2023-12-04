using DungeonCrawler.Domain.Enemies;
namespace DungeonCrawler.Domain.Hero {
    //+ +
    public class Gladiator : Hero {
        public Gladiator() : base("Gladiator", Utility.RandomInt(90, 100), Utility.RandomInt(10, 15), 10, 10) { }

        //+ +
        public override double AttackEnemy(Enemy enemy) {
            var x = Presentation.Presentation.ChooseAttackType(this);
            if (x == 1) {
                enemy.HitPoints -= Damage;
                return Damage;

            }
            else {
                HitPoints -= 0.1 * MaxHitPoints;
                enemy.HitPoints -= Damage * 2;
                return Damage * 2;
            }
        }
    }
}
