using DungeonCrawler.Domain.Enemies;
using DungeonCrawler.Domain.Hero;
using DungeonCrawler.Domain;
using DungeonCrawler.Presentation;

var hero = new Enchanter();//Presentation.ChooseHero();

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

static void ExecuteAttack(Enchanter hero, Enemy enemy, List<Enemy> enemies) {

    var enemyAttack = Enemy.ChooseAttack();
    Console.WriteLine(enemyAttack + "\n");
    var playerAttack = Presentation.ChooseAttack();
    string outputText;
    if (playerAttack == 3 && enemyAttack == 1) {
        outputText = enemy.AttackPlayer(hero, enemies);
    }
    else if (playerAttack == 1 && enemyAttack == 3) {
        outputText = hero.AttackEnemy(enemy);
    }
    else if (playerAttack < enemyAttack) {
        outputText = hero.AttackEnemy(enemy);
    }
    else if (playerAttack > enemyAttack) {
        outputText = enemy.AttackPlayer(hero, enemies);
    }
    else {
        outputText = "Izjednačeno";
    }
    Inputs.Wait(outputText);
}