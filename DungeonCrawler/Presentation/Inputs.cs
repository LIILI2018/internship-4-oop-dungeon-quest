using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Presentation {
    internal class Inputs {
        public static void Wait(string txt) {
            Console.WriteLine(txt);
            Console.WriteLine("Klikni enter da nastaviš: ");
            Console.ReadLine();
        }
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
    }
}
