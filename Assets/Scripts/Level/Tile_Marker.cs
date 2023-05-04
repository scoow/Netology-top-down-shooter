using System;
using TDShooter.Input;
using UnityEngine;

namespace TDShooter.Level
{
    /// <summary>
    /// Вешается на тайлы уровня
    /// </summary>
    public class Tile_Marker : MonoBehaviour
    {
        [SerializeField]
        private byte _number;
        public byte Number => _number;

        public Action<Tile_Marker> Callback;//todo переименовать
        /// <summary>
        /// Если игрок наступает на тайл, оповещает об этом TilesManager
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent<PlayerControl>(out var playerControl)) return;

            Callback.Invoke(this);
        }
    }
}