using UnityEngine;
using TDShooter.Enemies;
using TDShooter.enums;

    namespace TDShooter.AI.PathFinder
{
    public class Position_Marker : MonoBehaviour
    {
        [SerializeField] private APathFinding _aPathFinding;
        private Transform _targetTile;//следущая точка
        private EnemyMove _enemyMove;

        private void Start()
        {
            _enemyMove = GetComponentInParent<EnemyMove>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Tile tile))
            {
                if (tile.TileState != TileState.Obstacle)
                {
                    tile.SetTileState(TileState.Unit);
                    tile.mesh.material.color = Color.yellow;
                }
                    
                _aPathFinding._startPointTile = tile; //передаём клетку на которой стоит юнит
                _aPathFinding.PathFinding();

                //_enemyMove.SetNewTarget(_aPathFinding.ReturnNextPoint());//передаём промежуточную цель в класс движения врага
            }
        }

        public void TakeNewTarget(Transform newTarget)
        {
            _enemyMove.SetNewTarget(newTarget.transform);
        }

        private void OnTriggerExit(Collider other)
        {

            if (other.gameObject.TryGetComponent(out Tile tile))
            {
                if (tile.mesh.material.color != Color.red)
                    tile.mesh.material.color = Color.white;
            }
        }
    }
}