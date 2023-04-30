using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position_Marker : MonoBehaviour
{
    [SerializeField] private APathFinding _aPathFinding;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Tile tile))
        {
            if (tile.mesh.material.color != Color.red)
                tile.mesh.material.color = Color.yellow;
            _aPathFinding._startPointTile = tile; //������� ������ �� ������� ����� ����
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
