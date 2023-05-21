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
    public enum �haracterType
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
        None,//�����
        Unit,//������
        Obstacle,//�������
        ClosedList,//�����
        OpenedList,//����������
        Way//�������
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
        Explosive
    }
}