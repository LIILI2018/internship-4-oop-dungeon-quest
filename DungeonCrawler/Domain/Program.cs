using DungeonCrawler.Domain.Enemies;
using DungeonCrawler.Domain.Hero;
using DungeonCrawler.Domain;
using DungeonCrawler.Presentation;

var hero = Presentation.ChooseHero();

var enemies = new List<Enemy>();
for (int i = 0; i < 5; i++) {
    enemies.Add(Enemy.CreateEnemy());
}

StartGame();

void StartGame() {
    Console.Clear();
    Presentation.WriteEnemies(enemies);
        for (int i = 0; i < enemies.Count; i++) {
            while (enemies[i].IsAlive() && hero.IsAlive()) {
                Console.Clear();
                Presentation.WriteSituation(hero, enemies[i]);
                ExecuteAttack(hero, enemies[i], enemies);
            }
            if (hero.IsAlive()) {
                hero.Progress(enemies, i);
            }
            else {
                if (hero.Death()) {
                    break;
                }
            }
        }
        if (hero.IsAlive()) {
            Presentation.WinDialogue();
        }
        else {
            Presentation.DeathDialogue();
        }

}

static void ExecuteAttack(Hero hero, Enemy enemy, List<Enemy> enemies) {

    var enemyAttack = Enemy.ChooseAttack();
    Console.WriteLine(enemyAttack + "\n");
    var playerAttack = Presentation.ChooseAttack();

    if (playerAttack == 3 && enemyAttack == 1) {
        enemy.AttackPlayer(hero, enemies);
        Inputs.Wait($"{enemy.Name} te napada");
    }
    else if (playerAttack == 1 && enemyAttack == 3) {
        hero.AttackEnemy(enemy);
        Inputs.Wait($"Napadaš {enemy.Name}");

    }
    else if (playerAttack < enemyAttack) {
        hero.AttackEnemy(enemy);
        Inputs.Wait($"Napadaš {enemy.Name}");

    }
    else if (playerAttack > enemyAttack) {
        enemy.AttackPlayer(hero, enemies);
        Inputs.Wait($"{enemy.Name} te napada");
    }
    else {
        Inputs.Wait("Izjednačeno");
    }
}