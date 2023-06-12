using TDShooter.Configs;
using UnityEngine;

namespace TDShooter.Talents
{
    public class DroneAssist : MonoBehaviour
    {
        [SerializeField] Player_Data _playerData;

        private void OnEnable()
        {
            transform.position = _playerData.transform.position - new Vector3(2, 0, 0);
        }
        public void EnableDrone()
        {
            gameObject.SetActive(true);
        }

        public void DisableDrone()
        {
            gameObject.SetActive(false);
        }
    }
}