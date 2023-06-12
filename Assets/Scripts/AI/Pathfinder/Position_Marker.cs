using UnityEngine;
using TDShooter.Enemies;
using TDShooter.enums;

    namespace TDShooter.AI.PathFinder
{
    public class Position_Marker : MonoBehaviour
    {
        [SerializeField] private APathFinding _aPathFinding;
        private Transform _targetTile;//�������� �����
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
                    
                _aPathFinding._startPointTile = tile; //������� ������ �� ������� ����� ����
                _aPathFinding.PathFinding();

                //_enemyMove.SetNewTarget(_aPathFinding.ReturnNextPoint());//������� ������������� ���� � ����� �������� �����
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