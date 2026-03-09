//Exercise 1
public bool IsPlayerDead() {
    return health <= 0;
}
//Exercise 2
List<int> startingLevels = new List<int> { 1, 2, 3 };
//Exercise 3
void CheckEnemy(string enemyType) {
    if (enemyType == "Goblin" || enemyType == "Orc" || enemyType == "Troll") {
        Attack();
    } else {
        RunAway();
    }
}
//Exercise 4
float cooldownTimer = 5f;

void Update() {
    if (cooldownTimer > 0) {
        cooldownTimer -= Time.deltaTime;
    }
}
//Exercise 5
int GetHighestScore(int score1, int score2) {
    return Math.Max(score1, score2); 
    }