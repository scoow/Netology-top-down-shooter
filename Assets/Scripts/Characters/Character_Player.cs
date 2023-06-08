using TDShooter.Configs;

namespace TDShooter.Characters
{
    public class Character_Player : Character
    {
        public override void Die()
        {
            print("Игра окончена , монстры вас съели");
        }
        private void Awake()
        {
            _character_Data = GetComponent<Character_Data>();
            _character_UI = GetComponent<Character_UI>();
        }
    }
}