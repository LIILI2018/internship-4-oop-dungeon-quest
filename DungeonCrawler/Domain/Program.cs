using DungeonCrawler.Domain.Enemies;
using DungeonCrawler.Domain.Hero;
using DungeonCrawler.Domain;
using DungeonCrawler.Presentation;

var hero = Presentation.ChooseHero();

var enemies = new List<Enemy>();
for (int i = 0; i < 3; i++) {
	enemies.Add(Enemy.CreateEnemy());
}
foreach (Enemy enemy in enemies) { Console.WriteLine(enemy.GetType()); }

StartGame();

void StartGame() { 
	for (int i = 0; i < enemies.Count; i++) {
		while (enemies[i].IsAlive() && hero.IsAlive()) {
			Console.Clear();
			Presentation.WriteSituation(hero, enemies[i]);
			ExecuteAttack(hero, enemies[i]);
		}
		hero.Progress(enemies[i]);
	}
}
static void ExecuteAttack( Hero hero, Enemy enemy) {

	var enemyAttack = Enemy.ChooseAttack();
	Console.WriteLine(enemyAttack + "\n");
	var playerAttack = Presentation.ChooseAttack();

	if (playerAttack == 1 && enemyAttack == 3) {
		enemy.AttackPlayer(hero);
		Inputs.Wait("You attack enemy");
	}
	else if (playerAttack == 3 && enemyAttack == 1) {
		hero.AttackEnemy(enemy);
		Inputs.Wait("Enemy attacks you");

	}
	else if (playerAttack < enemyAttack) {
		hero.AttackEnemy(enemy);
		Inputs.Wait("Enemy attacks you");

	}
	else if (playerAttack > enemyAttack) {
		enemy.AttackPlayer(hero);
		Inputs.Wait("You attack enemy");

	}
	else {
		Inputs.Wait("Stalemate");
	}
}