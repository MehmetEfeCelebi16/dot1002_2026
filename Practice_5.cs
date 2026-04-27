public interface IWeapon
{
    void Attack();
    
}
public interface IRangedWeapon
{
    void Reload();
    void AimDownSights();
}
public class SniperRifle : IRangedWeapon,IWeapon
{
    public void Attack() { Console.WriteLine("Firing a high-caliber round!"); }
    public void Reload() { Console.WriteLine("Loading a new magazine."); }
    public void AimDownSights() { Console.WriteLine("Looking through the 8x scope."); }
}
public class Sword : IWeapon
{
    public void Attack()
 {
 Console.WriteLine("Swinging the sword!");
 }

}