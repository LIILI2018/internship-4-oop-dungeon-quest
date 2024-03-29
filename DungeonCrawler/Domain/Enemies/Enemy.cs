﻿using DungeonCrawler.Presentation;

namespace DungeonCrawler.Domain.Enemies {
    public abstract class Enemy {
        public string Name { get; set; }
        public double HitPoints { get; set; }
        public double ExperienceWorth { get; set; }
        public double Damage { get; set; }
        public bool CanAttack { get; set; } = true;
        public Enemy(string name, double HP, double XPW, double damage) {
            Name = name;
            HitPoints = HP;
            ExperienceWorth = XPW;
            Damage = damage;
        }

        public virtual string AttackPlayer(Hero.Hero hero1, List<Enemy> enemies) { return ""; }
        public static Enemy CreateEnemy() {
            var x = Utility.RandomInt();
            if (x < 50) {
                return new Goblin();
            }
            else if (x > 50 && x < 85) {
                return new Brute();
            }
            else {
                return new Witch();
            }
        }
        public static int ChooseAttack() {
            return Utility.RandomInt(1, 4);
        }
        public virtual void EnemyDeath(List<Enemy> enemies) {
            HitPoints = 0;
            Inputs.Wait("Ubio si " + Name +"a");
        }

    }
}
