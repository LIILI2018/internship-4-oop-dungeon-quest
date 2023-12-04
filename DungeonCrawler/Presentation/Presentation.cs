using DungeonCrawler.Domain;
using DungeonCrawler.Domain.Enemies;
using DungeonCrawler.Domain.Hero;

namespace DungeonCrawler.Presentation {
    public static class Presentation {
        public static Hero ChooseHero() {
            Console.WriteLine("Odaberi heroja");
            var x = Inputs.OptionInput(["1 - Gladiator", "2 - Enchanter", "3 - Marksman"]);
            switch (x) {
                case 1:
                    Hero hero = new Gladiator();
                    Inputs.Wait($"Odabrao si Gladijatora\n\nTvoja statistika: \nHitpoints: {hero.HitPoints} \nDamage: {hero.Damage}\nExperience: {hero.ExperiencePoints}");
                    return hero;
                case 2:
                    hero = new Enchanter();
                    Inputs.Wait($"Odabrao si Enchantera\n\nTvoja statistika: \nHitpoints: {hero.HitPoints} \nDamage: {hero.Damage}\nExperience: {hero.ExperiencePoints}");
                    return hero;
                default:
                    hero = new Marksman();
                    Inputs.Wait($"Odabrao si Mušketira\n\nTvoja statistika: \nHitpoints: {hero.HitPoints} \nDamage: {hero.Damage}\nExperience: {hero.ExperiencePoints}");
                    return hero;
            }
        }

        public static void WriteEnemies(List<Enemy> enemies) {
            Console.WriteLine("Neprijatelji s kojima ćeš se boriti: ");
            var i = 1;
            foreach (Enemy enemy in enemies) {
                Console.WriteLine($"{i++} {enemy.Name}");
            }
            Inputs.Wait("");
        }

        public static void WriteSituation(Hero hero, Enemy enemy) {
            Console.WriteLine($"{hero.Name} \nHitpoints: {hero.HitPoints}/{hero.MaxHitPoints} \nDamage: {hero.Damage}\nExperience: {hero.ExperiencePoints}/100");
            Console.WriteLine();
            Console.WriteLine($"{enemy.Name} \nHitpoints: {enemy.HitPoints} \nDamage: {enemy.Damage}\nExperience value: {enemy.ExperienceWorth}");
            Console.WriteLine();
        }

        public static int ChooseAttack() {
            return Inputs.OptionInput(["1 - Direktan napad", "2 - Napad sa strane", "3 - Protunapad"]);
        }

        public static bool DeathDialogue() {
            Inputs.Wait("Umro si");
            return Utility.PlayAgain();
        }

        public static void WinDialogue() { Console.WriteLine("Pobijedio si sve neprijatelje\nSada možeš dobiti osloboditi princezu iz kule..."); }
    }
}
