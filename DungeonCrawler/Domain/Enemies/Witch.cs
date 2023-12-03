using DungeonCrawler.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.Enemies {
	public class Witch : Enemy {
		public Witch() : base("Witch",Utility.RandomInt(15, 20), 40, Utility.RandomInt(30, 40)) { }
		public override void AttackPlayer(Hero.Hero hero,List<Enemy> enemies) {
			if (Utility.RandomInt() <= 10) {
				Inputs.Wait("Vještica igra đumbus");
				foreach (var enemy in enemies) {
					enemy.HitPoints *= Utility.RandomInt(60, 101);
				}
				hero.HitPoints *= Utility.RandomInt(60, 101);
			}
			else {
				hero.HitPoints -= Damage;
			}
		}
		public override void EnemyDeath(List<Enemy> enemies) {
			enemies.Add(Enemy.CreateEnemy());
			enemies.Add(Enemy.CreateEnemy());
		}
	}
}
