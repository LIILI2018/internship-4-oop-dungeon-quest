using DungeonCrawler.Domain.Hero;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.Enemies {
	public abstract class Enemy {
		public string Name { get; set; }
		public double HitPoints { get; set; }
		public double ExperienceWorth { get; set; }
		public double Damage { get; set; }

		public Enemy(string name, double HP, double XPW, double damage) {
			Name = name;
			HitPoints = HP;
			ExperienceWorth = XPW;
			Damage = damage;
		}



		public virtual void AttackPlayer(Hero.Hero hero1, List<Enemy> enemies) { }
		public bool IsAlive() {
			if (HitPoints > 0) return true;
			else return false;
		}
		public static Enemy CreateEnemy() {
			var x = Utility.RandomInt(0, 101);
			if (x < 50) {
				return new Goblin();
			}
			else if (x > 50 && x < 85) {
				return new Brute();
			}
			else{
				return new Witch();
			}
		}		
		public static int ChooseAttack() {
			return Utility.RandomInt(1, 4);
		}
		public virtual void EnemyDeath(List<Enemy> enemies) {}

	}
}
