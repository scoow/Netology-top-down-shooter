using UnityEngine;
using TDShooter.Enemies;

    namespace TDShooter.AI.PathFinder
{
    public class Position_Marker : MonoBehaviour
    {
        [SerializeField] private APathFinding _aPathFinding;
        private Transform _targetTile;//�������� �����
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
                _aPathFinding._startPointTile = tile; //������� ������ �� ������� ����� ����
                _aPathFinding.PathFinding();

                _enemyMove.SetNewTarget(_aPathFinding.ReturnNextPoint());//������� ������������� ���� � ����� �������� �����
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