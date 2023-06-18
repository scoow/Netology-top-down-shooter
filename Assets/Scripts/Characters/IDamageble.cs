namespace TDShooter.Characters
{
    public interface IDamageble
    {
        public int HP { get; }
        public void TakeDamage(int damage);
        public void TakeHeal(int heal);
        public void Die();
    }
}