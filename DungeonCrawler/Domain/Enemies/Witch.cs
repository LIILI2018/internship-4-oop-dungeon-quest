using DungeonCrawler.Presentation;

namespace DungeonCrawler.Domain.Enemies {
    public class Witch : Enemy {
        public Witch() : base("Vještica", Utility.RandomInt(30,35), 40, Utility.RandomInt(30, 40)) { }
        public override string AttackPlayer(Hero.Hero hero, List<Enemy> enemies) {
            if (CanAttack) {
                //+ +
                if (Utility.RandomInt() <= 10) {
                    foreach (var enemy in enemies) {
                        enemy.HitPoints *= Utility.RandomInt(60, 101)/100;
                    }
                    hero.HitPoints *= Utility.RandomInt(60, 101)/100;
                    return "Vještica napada sa đumbusom";
                }
                //+ +
                else {
                    hero.HitPoints -= Damage;
                    return "Vještica te napada";
                }
            }
            else {
                CanAttack = true;
                return "Vještica te ne može napasti";
            }
        }
        public override void EnemyDeath(List<Enemy> enemies) {
            base.EnemyDeath(enemies);
            enemies.Add(Enemy.CreateEnemy());
            enemies.Add(Enemy.CreateEnemy());
            Inputs.Wait("Vještica je stvorila 2 nova neprijtelja");
        }
    }
}
