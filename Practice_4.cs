public class EnemyNPC
{
    public string Name{ get; set; }
    public int AtackPower{ get; set; }
}
public class ChaseController
{
    public void ChasePlayer()
    {
        // AI Pathfinding algorithms to find and follow the player...
    }
}
public class LootDropManager
{
    public void DropLoot()
    {
        // Spawning gold or items on the ground when the enemy dies...
    }
}
public class Renderer
{
    public void RenderHealthBar()
    {
        // Drawing UI elements on the screen to show enemy's remaining health...

    }
}