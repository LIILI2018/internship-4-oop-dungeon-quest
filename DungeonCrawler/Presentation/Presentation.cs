using DungeonCrawler.Domain.Enemies;
using DungeonCrawler.Domain.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Presentation {
	internal class Presentation {
		public static Hero ChooseHero() {
			Console.WriteLine("Choose hero");
			var x = Inputs.OptionInput(["1 - Gladiator", "2 - Enchanter", "3 - Marksman"]);
			switch (x) {
				case 1:
					return new Gladiator();
				case 2:
					return new Enchanter();
				default:
					return new Marksman();
			}
		}

		public static void WriteSituation(Hero hero, Enemy enemy) {
            Console.WriteLine($"{hero.Name} \nHitpoints:{hero.HitPoints} \nDamage:{hero.Damage}");
            Console.WriteLine();
            Console.WriteLine($"{enemy.Name} \nHitpoints:{enemy.HitPoints} \nDamage:{enemy.Damage}");
            Console.WriteLine();
        }
		public static int ChooseAttack() {
			return Inputs.OptionInput(["1 - Direct attack", "2 - Side attack", "3 - Counter attack"]);
		}

	}
}
