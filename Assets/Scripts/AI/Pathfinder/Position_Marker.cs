using UnityEngine;
using TDShooter.Enemies;

    namespace TDShooter.AI.PathFinder
{
    public class Position_Marker : MonoBehaviour
    {
        [SerializeField] private APathFinding _aPathFinding;
        private Transform _targetTile;//следущая точка
        private EnemyMove _enemyMove;

        private void Start()
        {
            _enemyMove = GetComponent<EnemyMove>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Tile tile))
            {
                if (tile.mesh.material.color != Color.red)
                    tile.mesh.material.color = Color.yellow;
                _aPathFinding._startPointTile = tile; //передаём клетку на которой стоит юнит
                _aPathFinding.PathFinding();

                _enemyMove.SetNewTarget(_aPathFinding.ReturnNextPoint());//передаём промежуточную цель в класс движения врага
            }
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