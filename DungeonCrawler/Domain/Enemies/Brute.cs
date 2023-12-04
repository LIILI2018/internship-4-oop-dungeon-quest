namespace DungeonCrawler.Domain.Enemies {
    internal class Brute : Enemy {
        public Brute() : base("Brute", Utility.RandomInt(15, 20), 40, Utility.RandomInt(30, 40)) { }
        public override string AttackPlayer(Hero.Hero hero, List<Enemy> enemies) {
            if (CanAttack) {
                if (Utility.RandomInt() <= 30) {
                    hero.HitPoints *= 0.70;
                    return "Brute te kritično napada";
                }
                else {
                    hero.HitPoints -= Damage;
                    return "Brute te napada";

                }
            }
            else {
                CanAttack = true;
                return "Brute te ne može napasti";
            }
        }
    }
}