using DungeonCrawler.Domain.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Presentation {
	internal class Presentation {
		public static int ChooseAttack() {
			return OptionInput(["1 - Direktan napad", "2 - Napad s boka", "3 - Protunapad"]);
		}
		public static Hero ChooseHero() {
			Console.WriteLine("Choose hero");
			var x = OptionInput(["1 - Gladiator", "2 - Enchanter", "3 - Marksman"]);
			switch (x) {
				case 1:
					return new Gladiator();
				case 2:
					return new Enchanter();
				default:
					return new Marksman();
			}
		}
		public static int IntInput(string txt) {
			Console.WriteLine(txt);
			int y;
			bool success = false;
			do {
				success = int.TryParse(Console.ReadLine(), out y);
			} while (!success);
			Console.Clear();
			return y;
		}
		// + +
		public static string StringInput(string txt) {
			Console.WriteLine(txt);
			var y = Console.ReadLine();
			Console.Clear();
			return y;
		}
		//+ +
		public static DateTime DateInput(string txt) {
			Console.WriteLine(txt);
			DateTime y;
			bool success = false;
			do {
				success = DateTime.TryParse(Console.ReadLine(), out y);
			} while (!success);
			Console.Clear();

			return y;
		}
		//+ +
		public static double DoubleInput(string txt) {
			Console.WriteLine(txt);
			double y;
			bool success = false;
			do {
				success = double.TryParse(Console.ReadLine(), out y);
			} while (!success);
			Console.Clear();

			return y;
		}
		//+ +
		public static long LongInput(string txt) {
			Console.WriteLine(txt);
			long y;
			bool success = false;
			do {
				success = long.TryParse(Console.ReadLine(), out y);
			} while (!success);
			Console.Clear();

			return y;
		}
		//+ +
		public static void Wait(string txt) {
			Console.WriteLine(txt);
			Console.WriteLine("Klikni enter za nastavak: ");
			Console.ReadLine();
		}
		//+ +
		public static int OptionInput(List<string> txt) {
			foreach (var item in txt) {
				Console.WriteLine(item);
			}
			int y = 0;
			bool success = false;
			do {
				success = int.TryParse(Console.ReadLine(), out y);
			} while (!success || y > txt.Count() || y < 1);
			Console.Clear();
			return y;
		}
		// + +
		public static int RangeElementInput(int num1, int num2, string txt) {
			Console.WriteLine(txt);
			int y = 0;
			bool success = false;
			do {
				success = int.TryParse(Console.ReadLine(), out y);
			} while (!success || y < num1 || y > num2);
			Console.Clear();
			return y;
		}

	}
}
