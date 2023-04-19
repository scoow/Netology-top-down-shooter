namespace TDShooter.Characters
{
    public interface IHaveHP
    {
        public int HP { get; }
        public void TakeDamage(int damage);
        public void TakeHeal(int heal);
        public void Die();
    }
}