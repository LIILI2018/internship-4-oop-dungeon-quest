using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.Enemies {
	class Goblin : Enemy {
		public Goblin() : base(Utility.RandomInt(15, 20), 40, Utility.RandomInt(30, 40)) { }
	}
}
