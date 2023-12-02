using DungeonCrawler.Domain.Enemies;
using DungeonCrawler.Domain.Hero;
using DungeonCrawler.Domain;
using DungeonCrawler.Presentation;

var hero = Presentation.ChooseHero();
var enemies = new List<Enemy>();
for (int i = 0; i < 3; i++) {
	var x = Utility.RandomInt(0, 101);
	if (x < 50) {
		enemies.Add(new Goblin());
	}
	else if (x > 50 && x < 85) {
		enemies.Add(new Brute());
	}
	else if (x > 85) {
		enemies.Add(new Witch());
	}
}
foreach (Enemy enemy in enemies) { Console.WriteLine(enemy.GetType()); }

for (int i = 0; i < enemies.Count(); i++) {
	while (enemies[i].IsAlive()) {
		var playerAttack = Presentation.ChooseAttack();
		var enemyAttack = Enemy.ChooseAttack();
		ExecuteAtteck(playerAttack, enemyAttack, hero, enemies[i]);
	}
}
static void ExecuteAtteck(int playerAttack, int enemyAttack, Hero hero, Enemy enemy) {
	;
	if (playerAttack == 1 && enemyAttack == 3) {
		enemy.AttackPlayer();
	}
	else if (playerAttack == 3 && enemyAttack == 1) {
		hero.AttackEnemy(enemy);
	}
	else if (playerAttack < enemyAttack) {
		hero.AttackEnemy(enemy);
	}
	else if (playerAttack > enemyAttack) {
		enemy.AttackPlayer();

	}
}