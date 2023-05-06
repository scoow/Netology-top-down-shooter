namespace TDShooter.enums
{
    public enum Direction
    {
        Up, Down, Left, Right
    }
    public enum ProjectileType
    {
        Bullet
    }
    public enum СharacterType
    {
        Player,
        FastMeleeEnemy
    }
    public enum EffectType
    {
        Health,
        Armor,
        SpeedMove,
        MissChance,
        CriticalDamageChance
    }
    public enum TileState
    {
        None,//белый
        Unit,//желтый
        Obstacle,//красный
        ClosedList,//серый
        OpenedList,//фиолетовый
        Way//зеленый
    }
}