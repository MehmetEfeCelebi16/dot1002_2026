//Exercise 1
public class HealthPotion {
    public int healAmount = 10;

    public void Consume(Player player) {
        player.Heal(healAmount);
    }
}
//Exercise 2
public class CollectibleDot {
    public int pointValue = 10;

    public void Collect(Player player) {
        player.AddScore(pointValue);
    }
}
//Exercise 3
public class Spaceship {
    public float moveSpeed = 5f;

    public void MoveHorizontal(float input) {
        transform.Translate(Vector3.right * input * moveSpeed * Time.deltaTime);
    }
}
//Exercise 4
public class PlayerStats {
    public float jumpForce = 5f;
}
//Exercise 5
public interface IWeaponSystem {
    void Fire();
    void Reload();
}

public class Pistol : IWeaponSystem {
    public void Fire(){
    }

    public void Reload()
    {
        
    }
}