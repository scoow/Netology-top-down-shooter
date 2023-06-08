using UnityEngine;

namespace TDShooter.Weapons
{
    public class FolowerUpdate : Follower
    {
        private void Update()
        {
            Move(Time.deltaTime);
        }
    }
}