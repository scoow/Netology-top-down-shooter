using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDShooter.AI.PathFinder
{
    public class EndPoint : MonoBehaviour
    {
        //[SerializeField] private APathFinding _aPathFinding;

        public Action<Tile> OnEndPoint;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Tile tile))
            {
                if (tile.TileState != enums.TileState.Obstacle)
                {
                    tile.mesh.material.color = Color.green;
                    tile.SetTileState(enums.TileState.Unit);
                }
                    
                //_aPathFinding._endPointTile = tile; //передаём конечную клетку
                OnEndPoint?.Invoke(tile);
            }
        }

        private void OnTriggerExit(Collider other)
        {

            if (other.gameObject.TryGetComponent(out Tile tile))
            {
                if (tile.TileState != enums.TileState.Obstacle)
                {
                    tile.mesh.material.color = Color.white;
                    tile.SetTileState(enums.TileState.None);
                }
            }
        }
    }
}