using System;
using UnityEngine;

namespace TDShooter.Level
{
    /// <summary>
    /// Вешается на тайлы уровня
    /// </summary>
    public class Tile_Marker : MonoBehaviour
    {
        [SerializeField]
        public byte number;

        public Action<Tile_Marker> Callback;
        /// <summary>
        /// Если игрок наступает на тайл, оповещает об этом TilesManager
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter(Collision collision)
        {
            Callback.Invoke(this);
        }
    }
}