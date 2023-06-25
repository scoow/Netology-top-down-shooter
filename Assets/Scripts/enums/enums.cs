namespace TDShooter.enums
{
    public enum Direction : byte
    {
        Up, Down, Left, Right
    }
    public enum ProjectileType : byte
    {
        Bullet,
        Plasma,
        BFG
    }
    public enum СharacterType : byte
    {
        Player,
        FastMeleeEnemy,
        Spider,
        //Devil_Bulldog
    }
    public enum EffectType : byte
    {
        Health,
        Armor,
        MoveSpeed,
        MissChance,
        CriticalDamageChance,
        Weapon
    }
    public enum VisualEffectType : byte
    {
        BloodStain
    }
    public enum TileState : byte
    {
        None,//белый
        Unit,//желтый
        Obstacle,//красный
        ClosedList,//серый
        OpenedList,//фиолетовый
        Way//зеленый
    }
    public enum GameEventType : byte
    {
        StartGame,
        EndGame,
        PlayerDied,
        EnemyDied,
        EnemySpawned,
        EnemyAttacked,
        PlayShootSound,
        PlayStepSound,
        PlayerLevelUp,
        PortalActivated
    }
    public enum WeaponType : byte
    {
        Sword,
        Pistol,
        Machinegun,
        Plasmagun,
        Shothun,
        BFG
    }
    public enum GrenadeType : byte
    {
        Explosive,
        MolotovСocktail
    }
    public enum UpdateViewType : byte
    {
        CurrentKills,
        TargetKills,
        LevelUp,
        UpdateHP,
        UpdateAmmo
    }
    public enum TalentType : byte
    {
        StoneSkin,//дополнительная броня
        Radar,//миникарта, показывающая врагов
        ExtraFireRate,//увеличенная скорострельность
        ExtraWeaponDamage,//увеличенный урон
        Drone,//дрон-помощник
        NuclearCharge//бомба, убивающая всех врагов на экране
    }

    public enum SceneExample : byte
    {
        NewGame,
        MainMenu,
        Exit,
    }
    public enum EnemyAnimationState : byte
    {
        Move,
        Attack,
        Health,
        SpecialAtack,
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