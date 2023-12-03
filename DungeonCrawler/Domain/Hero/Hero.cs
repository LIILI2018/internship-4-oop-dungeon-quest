using DungeonCrawler.Domain.Enemies;

namespace DungeonCrawler.Domain.Hero {
	public abstract class Hero {
		public string Name { get; set; }
		public double HitPoints { get; set; }
		public double MaxHitPoints { get; set; }
		public double ExperiencePoints { get; set; }
		public double Damage { get; set; }
		public double MaxHPIncrease { get; set; }
		public double DamageIncrease { get; set; }



		public Hero(string name,double hp, double damage, double hpIncrease, double dmgIncrease) {
			Name = name;
			MaxHitPoints = hp;
			ExperiencePoints = 0;
			Damage = damage;
			MaxHPIncrease = hpIncrease;
			DamageIncrease = dmgIncrease;
			HitPoints = hp;
		}

		public virtual void AttackEnemy(Enemy enemy) {}
		public void LevelUp() {
			if (ExperiencePoints > 100) {
				MaxHitPoints += MaxHPIncrease;
				Damage += DamageIncrease;
				ExperiencePoints -= 100;
			}
		}

		public bool IsAlive() {
			if (HitPoints > 0) return true;
			else return false;
		}
		public void Heal() {
			HitPoints += MaxHitPoints * 0.25;
			if (HitPoints > MaxHitPoints) {
				HitPoints = MaxHitPoints;
			}
		}
		public void Progress(List<Enemy> enemies,int i) {
			ExperiencePoints += enemies[i].ExperienceWorth;
			LevelUp();
			Heal();
			enemies[i].EnemyDeath(enemies);
		}
	}
}
