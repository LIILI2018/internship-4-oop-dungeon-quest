using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.Enemies {
	public abstract class Enemy {
		public double HitPoints { get; set; }
		public double ExperienceWorth { get; set; }
		public double Damage { get; set; }

		public Enemy(double HP, double XPW, double damage) {
			HitPoints = HP;
			ExperienceWorth = XPW;
			Damage = damage;
		}
		public static int ChooseAttack() {
			return Utility.RandomInt(1, 4);
		}

		public virtual void AttackPlayer() { }

		public bool IsAlive() {
			if (HitPoints > 0) return true;
			else return false;
		}
	}
}
