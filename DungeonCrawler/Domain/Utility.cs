using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain {
	internal class Utility {
		public static int RandomInt(int low, int high) {
			return new Random().Next(low, high);
		}
		public static int RandomInt() {
			return new Random().Next(1, 101);
		}
	}
}
