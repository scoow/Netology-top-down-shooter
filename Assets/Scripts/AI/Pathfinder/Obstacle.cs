using UnityEngine;

namespace TDShooter.AI.PathFinder
{
    public class Obstacle : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Tile tile))
            {
                tile.mesh.material.color = Color.red;
                tile.SetTileState(enums.TileState.Obstacle);
            }
        }

        private void OnTriggerExit(Collider other)
        {

            if (other.gameObject.TryGetComponent(out Tile tile))
            {
                tile.mesh.material.color = Color.white;
                tile.SetTileState(enums.TileState.None);
            }
        }
    }
}