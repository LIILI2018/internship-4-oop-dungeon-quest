using DungeonCrawler.Domain.Enemies;

namespace DungeonCrawler.Domain.Hero {
    public class Marksman : Hero {
        private double _critcalChance { get; set; } = 20;
        private double _stunChance { get; set; } = 20;
        public Marksman() : base("Mušketir", Utility.RandomInt(90, 111), Utility.RandomInt(30, 50), 30, 15) { }

        public override string AttackEnemy(Enemy enemy) {
            var x = Utility.RandomInt();
            if (x < _critcalChance) {
                enemy.HitPoints -= Damage * 2;
                return $"Kritično si napao {enemy.Name}";
            }
            else if (x > (100 - _stunChance)) {
                enemy.HitPoints -= Damage;
                enemy.CanAttack = false;
                return $"Napao si i stunao {enemy.Name}";
            }
            else {
                enemy.HitPoints -= Damage;
                return $"Napao si {enemy.Name}";
            }
        }

        protected override void LevelUp() {
            base.LevelUp();
            if (ExperiencePoints > 100) {
                _critcalChance += 5;
                _stunChance += 5;
            }
        }
    }
}
