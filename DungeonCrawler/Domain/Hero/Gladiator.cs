using DungeonCrawler.Domain.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonCrawler.Domain.Hero {
	public class Gladiator : Hero {
		public Gladiator() : base(Utility.RandomInt(90, 100), Utility.RandomInt(10, 15), 10, 10) { }

		public override void AttackEnemy(Enemy enemy) {
			enemy.HitPoints -= Damage;
		}
		public void RageAttack() {
			/*TODO*/
		}
	}
}
