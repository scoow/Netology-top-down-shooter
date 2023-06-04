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
        MoveSpeed,
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
        Sword,
        Pistol,
        Machinegun,
        Plasmagun
    }
    public enum GrenadeType
    {
        Explosive,
        MolotovСocktail
    }
    public enum UpdateViewType
    {
        CurrentKills,
        TargetKills,
        LevelUp,
        UpdateHP,
        UpdateAmmo
    }    
}