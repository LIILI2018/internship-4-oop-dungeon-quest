using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.Hero {
	public class Enchanter : Hero {
		private double Mana { get; set; }
		private bool CanReturnFromDead { get; set; } = false;
		public Enchanter() : base("Enchanter", Utility.RandomInt(50, 60), Utility.RandomInt(40, 50), 10, 10) { }

		public void ReturnFromDead() {
			/*TODO*/
		}
		public void Heal() {
			/*TODO*/
		}

	}
}
