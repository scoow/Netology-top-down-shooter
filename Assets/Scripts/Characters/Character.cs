using UnityEngine;

namespace TDShooter.Characters
{
    /// <summary>
    /// ��������. �� ������� - �����-�������� ��� ������ � ������
    /// </summary>
    public class Character : MonoBehaviour, IHaveHP
    {
        [SerializeField]
        private int _hp;
        public int HP => _hp;

        public void Die()
        {
            this.gameObject.SetActive(false);
        }

        public void TakeDamage(int damage)
        {
            _hp -= damage;
            Debug.Log("HP ��������:" + _hp);
            if (_hp <= 0)
                Die();
        }

        public void TakeHeal(int heal)
        {
            _hp += heal;
        }
    }
}