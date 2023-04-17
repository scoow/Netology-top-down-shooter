using System;
using UnityEngine;

namespace TDShooter.Level
{
    public class Tile_Marker : MonoBehaviour
    {
        [SerializeField]
        public byte number;

        public Action<Tile_Marker> Callback;

        private void OnCollisionEnter(Collision collision)
        {
            Callback.Invoke(this);
        }
    }
}