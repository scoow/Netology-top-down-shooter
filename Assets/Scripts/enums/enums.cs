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
    public enum EnemyType
    {
        FastMelee
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
}