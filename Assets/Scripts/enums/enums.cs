namespace TDShooter.enums
{
    public enum Direction
    {
        Up, Down, Left, Right
    }
    public enum ProjectileType
    {
        Bullet,
        Plasma
    }
    public enum СharacterType
    {
        Player,
        FastMeleeEnemy,
        Spider
    }
    public enum EffectType
    {
        Health,
        Armor,
        SpeedMove,
        MissChance,
        CriticalDamageChance,
        Weapon
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
    public enum GameEventType
    {
        StartGame,
        EndGame,
        PlayerDied,
        EnemyDied
    }
    public enum WeaponType
    {
        Machinegun,
        Plasmagun
    }
    public enum GrenadeType
    {
        Explosive,
        MolotovСocktail
    }
}