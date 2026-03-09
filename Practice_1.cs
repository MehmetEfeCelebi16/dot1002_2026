//Exercise 1
public Text goldText;
public Text crystalText;
public Text foodText;
public Text ironText;

void UpdateResource(Text resourceText, int amount){
    resourceText.text = "Amount: " + amount.ToString();
}
//Exercise 2
void PlaySound(AudioClip clip) {
    AudioSource audio = GetComponent<AudioSource>();
    audio.clip = clip;
    audio.Play();
}

void Jump() {
    PlaySound(jumpSound);
    rb.velocity = Vector2.up * jumpForce;
}

void Shoot() {
    PlaySound(shootSound);
    Instantiate(bullet);
}
//Exercise 3
void ApplyDamage(int amount) {
    health -= amount;
    if (health < 0) health = 0;
    Debug.Log("Health: " + health);
}

void TakePhysicalDamage(int amount) => ApplyDamage(amount);
void TakeMagicDamage(int amount) => ApplyDamage(amount);
//Exercise 4
void SpawnEnemy(GameObject enemyPrefab) {
    Vector3 spawnPos = transform.position + Vector3.up;
    Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    PlaySpawnParticle(spawnPos);
}
//Exercise 5
float mapLimit = 100f;

void Move(Vector3 direction) {
    float newX = transform.position.x + direction.x;
    if (newX <= mapLimit && newX >= -mapLimit) {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}