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
        Spider,
        //Devil_Bulldog
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
        Plasmagun,
        Shothun
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
    public enum TalentType
    {
        StoneSkin,//дополнительная броня
        Radar,//миникарта, показывающая врагов
        ExtraFireRate,//увеличенная скорострельность
        ExtraWeaponDamage,//увеличенный урон
        Drone,//дрон-помощник
        NuclearCharge//бомба, убивающая всех врагов на экране
    }

    public enum SceneExample
    {
        NewGame,
        MainMenu,
        Exit,
    }
    public enum EnemyAnimationState
    {
        Move,
        Atack,
        Death
    }

    public enum IgnoreAxisType : byte
    {
        None = 0,
        X = 1,
        Y = 2,
        Z = 4
    }
}