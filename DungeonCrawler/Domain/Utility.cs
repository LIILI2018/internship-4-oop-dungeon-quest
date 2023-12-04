using DungeonCrawler.Presentation;
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
        public static double RandomDouble(int low, int high) {
            return new Random().Next(low, high);
        }
		public static bool PlayAgain() {
			var x = Inputs.OptionInput(["1 - Želiš igrati ponovo","2 - Završi program"]);
			if (x == 1) {
				return true;
			}
			return false;
		}
    }
}
