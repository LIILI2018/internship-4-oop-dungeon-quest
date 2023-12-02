using DungeonCrawler.Domain.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.Hero {
	public abstract class Hero {
		protected double HitPoints { get; set; }
		public double ExperiencePoints { get; set; }
		protected double Damage { get; set; }
		protected double HPIncrease { get; set; }
		protected double DamageIncrease { get; set; }



		internal Hero(double hp, double damage, double hpIncrease, double dmgIncrease) {
			HitPoints = hp;
			ExperiencePoints = 0;
			Damage = damage;
			HPIncrease = hpIncrease;
			DamageIncrease = dmgIncrease;
		}

		public virtual void AttackEnemy(Enemy enemy) {}
		public virtual void LevelUp(double HPIncrease, double DamageIncrease) {
			if (ExperiencePoints > 100) {
				HitPoints += HPIncrease;
				Damage += DamageIncrease;
				ExperiencePoints -= 100;
			}
		}

		public bool IsAlive() {
			if (HitPoints > 0) return true;
			else return false;
		}
	}
}
