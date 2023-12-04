using DungeonCrawler.Domain.Enemies;
using DungeonCrawler.Presentation;

namespace DungeonCrawler.Domain.Hero {
    public abstract class Hero {
        public string Name { get; set; }
        public double HitPoints { get; set; }
        public double MaxHitPoints { get; set; }
        public double ExperiencePoints { get; set; }
        public double Damage { get; set; }
        protected double _maxHPIncrease { get; set; }
        protected double _damageIncrease { get; set; }

        public Hero(string name, double hp, double damage, double hpIncrease, double dmgIncrease) {
            Name = name;
            MaxHitPoints = hp;
            ExperiencePoints = 0;
            Damage = damage;
            _maxHPIncrease = hpIncrease;
            _damageIncrease = dmgIncrease;
            HitPoints = hp;
        }

        public virtual string AttackEnemy(Enemy enemy) { return ""; }

        protected virtual void LevelUp() {
            if (ExperiencePoints >= 100) {
                MaxHitPoints += _maxHPIncrease;
                Damage += _damageIncrease;
                ExperiencePoints -= 100;
                Inputs.Wait($"Postigao si novi level\nHP ti se povečao za {_maxHPIncrease}\nDamage ti se povečao za {_damageIncrease}");
            }
        }

        public bool IsAlive() {
            if (HitPoints > 0) return true;
            else return false;
        }

        protected virtual void Heal() {
            HitPoints += MaxHitPoints * 0.4;
            if (HitPoints > MaxHitPoints) {
                HitPoints = MaxHitPoints;
            }
        }

        public void Progress(List<Enemy> enemies, int i) {
            ExperiencePoints += enemies[i].ExperienceWorth;
            LevelUp();
            Heal();
            enemies[i].EnemyDeath(enemies);
        }
        public virtual bool SecondLife() { return false; }
    }
}