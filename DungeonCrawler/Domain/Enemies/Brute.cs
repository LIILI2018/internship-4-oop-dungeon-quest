﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.Enemies {
	internal class Brute : Enemy {
		public Brute() : base("Brute", Utility.RandomInt(15, 20), 40, Utility.RandomInt(30, 40)) { }
		public override void AttackPlayer(Hero.Hero hero, List<Enemy> enemies) {
			if (Utility.RandomInt() <= 20) {
				hero.HitPoints *= 0.80;
			}
			else {
				hero.HitPoints -= Damage;
			}
		}
	}
}
